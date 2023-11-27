using AutoMapper;
using Cocktails.API.Models;
using Cocktails.API.Services;
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCocktail(
            int id,
            bool includeIngredients = false)
        {
            var cocktail = await _cocktailsRepository.GetCocktailAsync(id, includeIngredients);

            if (cocktail == null)
            {
                _logger.LogInformation(
                    $"Cocktail with id {id} was not found in the cocktails.");

                return NotFound();
            }

            if (includeIngredients)
            {
                return Ok(_mapper.Map<CocktailDto>(cocktail));
            }

            return Ok(_mapper.Map<CocktailWithoutIngredientsDto>(cocktail));
        }
    }
}
