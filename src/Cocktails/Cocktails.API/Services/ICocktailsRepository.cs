using Cocktails.API.Entities;

namespace Cocktails.API.Services
{
    public interface ICocktailsRepository
    {
        Task<IEnumerable<Cocktail>> GetCocktailsAsync();
    }
}
