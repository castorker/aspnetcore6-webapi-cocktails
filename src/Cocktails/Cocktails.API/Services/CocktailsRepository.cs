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
    }
}
