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
    }
}
