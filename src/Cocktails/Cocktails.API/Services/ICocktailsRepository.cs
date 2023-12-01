using Cocktails.API.Entities;

namespace Cocktails.API.Services
{
    public interface ICocktailsRepository
    {
        Task<IEnumerable<Cocktail>> GetCocktailsAsync();
        Task<(IEnumerable<Cocktail>, PaginationMetadata)> GetCocktailsAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Cocktail?> GetCocktailAsync(int cocktailId, bool includeIngredients);
        Task<bool> CocktailExistsAsync(string cocktailName);
        Task<bool> CocktailExistsAsync(int cocktailId);
        void AddCocktail(Cocktail cocktail);
        void DeleteCocktail(Cocktail cocktail);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Ingredient>> GetIngredientsAsync();
        Task<IEnumerable<Ingredient>> GetIngredientsAsync(string? name, string? searchQuery);
        Task<Ingredient?> GetIngredientAsync(int ingredientId, bool includeCocktails);
        Task<IList<Ingredient>> GetIngredientsByNameAsync(IList<string> ingredientNames);
        Task<bool> IngredientExistsAsync(string ingredientName);
        Task<bool> IngredientExistsAsync(int ingredientId);
        void AddIngredient(Ingredient ingredient);
        void SetIngredientEntityStateToModified(Ingredient ingredient);
        void DeleteIngredient(Ingredient ingredient);
    }
}
