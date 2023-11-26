using Cocktails.API.Entities;
using Cocktails.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cocktails.API.Controllers
{
    [ApiController]
    [Route("api/cocktails")]
    public class CocktailsController : ControllerBase
    {
        private readonly ICocktailsRepository _cocktailsRepository;

        public CocktailsController(ICocktailsRepository cocktailsRepository)
        {
            _cocktailsRepository = cocktailsRepository 
                ?? throw new ArgumentNullException(nameof(cocktailsRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cocktail>>> GetCocktails()
        {
            var cocktailEntities = await _cocktailsRepository.GetCocktailsAsync();
            return Ok(cocktailEntities);
        }
    }
}
