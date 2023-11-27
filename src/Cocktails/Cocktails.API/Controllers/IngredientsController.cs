using AutoMapper;
using Cocktails.API.Models;
using Cocktails.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cocktails.API.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly ICocktailsRepository _cocktailsRepository;
        private readonly IMapper _mapper;

        public IngredientsController(
            ICocktailsRepository cocktailsRepository,
            IMapper mapper)
        {
            _cocktailsRepository = cocktailsRepository 
                ?? throw new ArgumentNullException(nameof(cocktailsRepository));

            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientWithoutCocktailsDto>>> GetIngredients()
        {
            var ingredientEntities = await _cocktailsRepository.GetIngredientsAsync();

            return Ok(_mapper.Map<IEnumerable<IngredientWithoutCocktailsDto>>(ingredientEntities));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetIngredient(
            int id,
            bool includeCocktails = false)
        {
            var ingredient = await _cocktailsRepository.GetIngredientAsync(id, includeCocktails);

            if (ingredient == null)
            {
                return NotFound();
            }

            if (includeCocktails)
            {
                return Ok(_mapper.Map<IngredientDto>(ingredient));
            }

            return Ok(_mapper.Map<IngredientWithoutCocktailsDto>(ingredient));
        }
    }
}
