using Cocktails.API.Entities;

namespace Cocktails.API.Services
{
    public interface ICocktailsRepository
    {
        Task<IEnumerable<Cocktail>> GetCocktailsAsync();
        Task<Cocktail?> GetCocktailAsync(int cocktailId, bool includeIngredients);
        Task<IEnumerable<Ingredient>> GetIngredientsAsync();
        Task<Ingredient?> GetIngredientAsync(int ingredientId, bool includeCocktails);
        Task<bool> CocktailExistsAsync(string cocktailName);
        Task<bool> CocktailExistsAsync(int cocktailId);
        void AddCocktail(Cocktail cocktail);
        void DeleteCocktail(Cocktail cocktail);
        Task<bool> SaveChangesAsync();
    }
}
