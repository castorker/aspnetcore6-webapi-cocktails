using AutoMapper;
using Cocktails.API.Entities;
using Cocktails.API.Models;
using Cocktails.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cocktails.API.Controllers
{
    [ApiController]
    [Route("api/cocktails")]
    public class CocktailsController : ControllerBase
    {
        private readonly ICocktailsRepository _cocktailsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CocktailsController> _logger;

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
        public async Task<ActionResult<IEnumerable<CocktailWithoutIngredientsDto>>> GetCocktails()
        {
            var cocktailEntities = await _cocktailsRepository.GetCocktailsAsync();

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
        public async Task<ActionResult<CocktailDto>> CreateCocktail(
            [FromBody] CocktailForCreationDto cocktail)
        {
            cocktail.Name = cocktail.Name.Trim();
            if (await _cocktailsRepository.CocktailExistsAsync(cocktail.Name))
            {
                var responseMessage = $"Cocktail with name {cocktail.Name} already exists.";

                _logger.LogInformation(responseMessage);

                return BadRequest(responseMessage);
            }

            var cocktailToCreate = _mapper.Map<Cocktail>(cocktail);

            _cocktailsRepository.AddCocktail(cocktailToCreate);

            await _cocktailsRepository.SaveChangesAsync();

            var createdCocktailToReturn =
                _mapper.Map<CocktailDto>(cocktailToCreate);

            return CreatedAtRoute("GetCocktail",
                new { cocktailId = createdCocktailToReturn.Id, }, 
                createdCocktailToReturn);
        }

        [HttpPut("{cocktailid}")]
        public async Task<ActionResult> UpdateCocktail(int cocktailId,
            CocktailForUpdateDto cocktail)
        {
            var cocktailEntity = await _cocktailsRepository
                .GetCocktailAsync(cocktailId, false);

            if (cocktailEntity == null)
            {
                _logger.LogInformation(
                    $"No cocktail found with id {cocktailId}.");

                return NotFound();
            }

            _mapper.Map(cocktail, cocktailEntity);

            await _cocktailsRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{cocktailid}")]
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
