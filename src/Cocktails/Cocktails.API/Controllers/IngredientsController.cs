using AutoMapper;
using Cocktails.API.Entities;
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
    [Route("api/ingredients")]
    public class IngredientsController : ControllerBase
    {
        private readonly ICocktailsRepository _cocktailsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<IngredientsController> _logger;

        const int maxCocktailsPageSize = 30;

        public IngredientsController(
            ICocktailsRepository cocktailsRepository,
            IMapper mapper,
            ILogger<IngredientsController> logger)
        {
            _cocktailsRepository = cocktailsRepository
                ?? throw new ArgumentNullException(nameof(cocktailsRepository));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));

            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientWithoutCocktailsDto>>> GetIngredients(
            [FromQuery] string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxCocktailsPageSize)
            {
                pageSize = maxCocktailsPageSize;
            }

            var (ingredientEntities, paginationMetadata) = await _cocktailsRepository
                .GetIngredientsAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<IngredientWithoutCocktailsDto>>(ingredientEntities));
        }

        [HttpGet("{ingredientid}", Name = "GetIngredient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetIngredient(int ingredientId,
            bool includeCocktails = false)
        {
            var ingredient = await _cocktailsRepository.GetIngredientAsync(ingredientId, includeCocktails);

            if (ingredient == null)
            {
                _logger.LogInformation(
                    $"Ingredient with id {ingredientId} was not found in the ingredients.");

                return NotFound();
            }

            if (includeCocktails)
            {
                return Ok(_mapper.Map<IngredientDto>(ingredient));
            }

            return Ok(_mapper.Map<IngredientWithoutCocktailsDto>(ingredient));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IngredientDto>> CreateIngredient(
            [FromBody] IngredientForCreationDto ingredientDto)
        {
            ingredientDto.Name = ingredientDto.Name.Trim();
            if (await _cocktailsRepository.IngredientExistsAsync(ingredientDto.Name))
            {
                var responseMessage = $"Ingredient with name {ingredientDto.Name} already exists.";

                _logger.LogInformation(responseMessage);

                return BadRequest(responseMessage);
            }

            var ingredientToCreate = _mapper.Map<Ingredient>(ingredientDto);

            _cocktailsRepository.AddIngredient(ingredientToCreate);

            await _cocktailsRepository.SaveChangesAsync();

            var createdIngredientToReturn =
                _mapper.Map<IngredientDto>(ingredientToCreate);

            return CreatedAtRoute("GetIngredient",
                new { ingredientId = createdIngredientToReturn.Id, },
                createdIngredientToReturn);
        }

        [HttpPut("{ingredientid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateIngredient(int ingredientId,
            IngredientForUpdateDto ingredientDto)
        {
            if (ingredientId != ingredientDto.Id)
            {
                return BadRequest();
            }

            var ingredientToUpdate = _mapper.Map<Ingredient>(ingredientDto);
            _cocktailsRepository.SetIngredientEntityStateToModified(ingredientToUpdate);

            try
            {
                await _cocktailsRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _cocktailsRepository.IngredientExistsAsync(ingredientId))
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

        [HttpPatch("{ingredientid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartialUpdateIngredient(int ingredientId,
            JsonPatchDocument<IngredientForUpdateDto> patchDocument)
        {
            var ingredientEntity = await _cocktailsRepository
                .GetIngredientAsync(ingredientId, false);

            if (ingredientEntity == null)
            {
                _logger.LogInformation(
                    $"No ingredient found with id {ingredientId}.");

                return NotFound();
            }

            var ingredientToPatch = _mapper.Map<IngredientForUpdateDto>(ingredientEntity);

            patchDocument.ApplyTo(ingredientToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(ingredientToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(ingredientToPatch, ingredientEntity);

            await _cocktailsRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{ingredientid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteIngredient(int ingredientId)
        {
            var ingredientEntity = await _cocktailsRepository
                .GetIngredientAsync(ingredientId, false);

            if (ingredientEntity == null)
            {
                _logger.LogInformation(
                    $"No ingredient found with id {ingredientId}.");

                return NotFound();
            }

            _cocktailsRepository.DeleteIngredient(ingredientEntity);

            await _cocktailsRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
