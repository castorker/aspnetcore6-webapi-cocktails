using AutoMapper;
using Cocktails.API.Entities;
using Cocktails.API.Extensions;
using Cocktails.API.Models;
using Cocktails.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Cocktails.API.Controllers
{
    [ApiController]
    [Authorize(Policy = "MustBeAtLeast18YearsOld")]
    [Route("api/cocktails")]
    public class CocktailsController : ControllerBase
    {
        private readonly ICocktailsRepository _cocktailsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CocktailsController> _logger;

        const int maxCocktailsPageSize = 20;

        public CocktailsController(
            ICocktailsRepository cocktailsRepository,
            IMapper mapper,
            ILogger<CocktailsController> logger)
        {
            _cocktailsRepository = cocktailsRepository 
                ?? throw new ArgumentNullException(nameof(cocktailsRepository));
            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocktailWithoutIngredientsDto>>> GetCocktails(
            [FromQuery] string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxCocktailsPageSize)
            {
                pageSize = maxCocktailsPageSize;
            }

            var (cocktailEntities, paginationMetadata) = await _cocktailsRepository
                .GetCocktailsAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CocktailWithoutIngredientsDto>>(cocktailEntities));
        }

        [HttpGet("{cocktailid}", Name = "GetCocktail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCocktail(int cocktailId, bool includeIngredients = false)
        {
            var cocktail = await _cocktailsRepository.GetCocktailAsync(cocktailId, includeIngredients);

            if (cocktail == null)
            {
                _logger.LogInformation(
                    $"Cocktail with id {cocktailId} was not found in the cocktails.");

                return NotFound();
            }

            if (includeIngredients)
            {
                return Ok(_mapper.Map<CocktailDto>(cocktail));
            }

            return Ok(_mapper.Map<CocktailWithoutIngredientsDto>(cocktail));
        }

        [HttpPost]
        [Authorize(Policy = "UserCanAddCocktail")]
        [Authorize(Policy = "ClientApplicationCanWrite")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CocktailDto>> CreateCocktail(
            [FromBody] CocktailForCreationDto cocktail)
        {
            // get the SubjectId of the current user trying to create the cocktail
            var subjectId = User.Claims
                .FirstOrDefault(c => c.Type == "sub")?.Value;
            if (subjectId == null)
            {
                throw new Exception("User identifier is missing from token.");
            }

            cocktail.Name = cocktail.Name.Trim();
            if (await _cocktailsRepository.CocktailExistsAsync(cocktail.Name))
            {
                var responseMessage = $"Cocktail with name {cocktail.Name} already exists.";

                _logger.LogInformation(responseMessage);

                return BadRequest(responseMessage);
            }

            var cocktailToCreate = _mapper.Map<Cocktail>(cocktail);

            if (cocktail.Ingredients.Any())
            {
                IList<Ingredient> existingIngredients = await CheckIngredientsExist(cocktail);
                UpdateIngredientList(cocktailToCreate, existingIngredients);
            }

            _cocktailsRepository.AddCocktail(cocktailToCreate);

            await _cocktailsRepository.SaveChangesAsync();

            var createdCocktailToReturn =
                _mapper.Map<CocktailDto>(cocktailToCreate);

            return CreatedAtRoute("GetCocktail",
                new { cocktailId = createdCocktailToReturn.Id, },
                createdCocktailToReturn);
        }

        private static void UpdateIngredientList(Cocktail cocktailToCreate, IList<Ingredient> existingIngredients)
        {
            foreach (var item in existingIngredients)
            {
                var found = cocktailToCreate.Ingredients.Where(x => x.Name == item.Name).FirstOrDefault();
                if (found != null)
                {
                    cocktailToCreate.Ingredients.Remove(found);
                    cocktailToCreate.Ingredients.Add(item);
                }
            }
        }

        private async Task<IList<Ingredient>> CheckIngredientsExist(CocktailForCreationDto cocktail)
        {
            var ingredientNames = cocktail.Ingredients.Select(x => x.Name.Trim()).ToList();
            var existingIngredients = await _cocktailsRepository.GetIngredientsByNameAsync(ingredientNames);
            return existingIngredients;
        }

        [HttpPut("{cocktailid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCocktail(int cocktailId,
            CocktailForUpdateDto cocktail)
        {
            if (cocktailId != cocktail.Id)
            {
                return BadRequest();
            }

            var cocktailEntity = await _cocktailsRepository
                .GetCocktailAsync(cocktailId, true);

            if (cocktailEntity == null)
            {
                _logger.LogInformation(
                    $"No cocktail found with id {cocktailId}.");

                return NotFound();
            }

            cocktailEntity.Name = cocktail.Name;
            cocktailEntity.Description = cocktail.Description;

            if (cocktail.Ingredients.Any())
            {
                var ingredientNames = cocktail.Ingredients.Select(x => x.Name.Trim()).ToList();
                var existingIngredients = await _cocktailsRepository.GetIngredientsByNameAsync(ingredientNames);
                cocktailEntity.Ingredients.SetRelations(existingIngredients);
            }

            try
            {
                await _cocktailsRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _cocktailsRepository.CocktailExistsAsync(cocktailId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPatch("{cocktailid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartialUpdateCocktail(int cocktailId,
            JsonPatchDocument<CocktailForUpdateDto> patchDocument)
        {
            var cocktailEntity = await _cocktailsRepository
                .GetCocktailAsync(cocktailId, false);

            if (cocktailEntity == null)
            {
                _logger.LogInformation(
                    $"No cocktail found with id {cocktailId}.");

                return NotFound();
            }

            var cocktailToPatch = _mapper.Map<CocktailForUpdateDto>(cocktailEntity);

            patchDocument.ApplyTo(cocktailToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(cocktailToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(cocktailToPatch, cocktailEntity);

            await _cocktailsRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{cocktailid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCocktail(int cocktailId)
        {
            var cocktailEntity = await _cocktailsRepository
                .GetCocktailAsync(cocktailId, false);
            
            if (cocktailEntity == null)
            {
                _logger.LogInformation(
                    $"No cocktail found with id {cocktailId}.");

                return NotFound();
            }

            _cocktailsRepository.DeleteCocktail(cocktailEntity);

            await _cocktailsRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
