using Cocktails.API.DbContexts;
using Cocktails.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cocktails.API.Services
{
    public class CocktailsRepository : ICocktailsRepository
    {
        private readonly CocktailsDbContext _context;

        public CocktailsRepository(CocktailsDbContext context)
        {
            _context = context 
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Cocktail>> GetCocktailsAsync()
        {
            return await _context.Cocktails
                .OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<(IEnumerable<Cocktail>, PaginationMetadata)> GetCocktailsAsync(
            string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Cocktails as IQueryable<Cocktail>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(x => x.Name.Contains(searchQuery)
                || (x.Description != null && x.Description.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();
            
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection
                .OrderBy(c => c.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }

        public async Task<Cocktail?> GetCocktailAsync(int cocktailId, bool includeIngredients)
        {
            if (includeIngredients)
            {
                return await _context.Cocktails
                    .Include(c => c.Ingredients)
                    .Where(c => c.Id == cocktailId).FirstOrDefaultAsync();
            }

            return await _context.Cocktails
                    .Where(c => c.Id == cocktailId).FirstOrDefaultAsync();
        }

        public async Task<bool> CocktailExistsAsync(string cocktailName)
        {
            return await _context.Cocktails.AnyAsync(c => c.Name == cocktailName);
        }

        public async Task<bool> CocktailExistsAsync(int cocktailId)
        {
            return await _context.Cocktails.AnyAsync(c => c.Id == cocktailId);
        }

        public void AddCocktail(Cocktail cocktail)
        {
            _context.Cocktails.Add(cocktail);
        }

        public void DeleteCocktail(Cocktail cocktail)
        {
            _context.Cocktails.Remove(cocktail);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
        {
            return await _context.Ingredients
                .OrderBy(i => i.Name).ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsAsync(string? name, string? searchQuery)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(searchQuery))
            {
                return await GetIngredientsAsync();
            }

            var collection = _context.Ingredients as IQueryable<Ingredient>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(x => x.Name.Contains(searchQuery)
                || (x.Description != null && x.Description.Contains(searchQuery)));
            }

            return await collection.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Ingredient?> GetIngredientAsync(int ingredientId, bool includeCocktails)
        {
            if (includeCocktails)
            {
                return await _context.Ingredients
                    .Include(i => i.Cocktails)
                    .Where(i => i.Id == ingredientId).FirstOrDefaultAsync();
            }

            return await _context.Ingredients
                    .Where(i => i.Id == ingredientId).FirstOrDefaultAsync();
        }

        public async Task<IList<Ingredient>> GetIngredientsByNameAsync(IList<string> ingredientNames)
        {
            return await _context.Ingredients.Where(x => ingredientNames.Contains(x.Name)).ToListAsync();
        }

        public async Task<bool> IngredientExistsAsync(string ingredientName)
        {
            return await _context.Ingredients.AnyAsync(i => i.Name == ingredientName);
        }

        public async Task<bool> IngredientExistsAsync(int ingredientId)
        {
            return await _context.Ingredients.AnyAsync(i => i.Id == ingredientId);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
        }

        public void SetIngredientEntityStateToModified(Ingredient ingredient)
        {
            _context.Entry(ingredient).State = EntityState.Modified;
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
        }
    }
}
