using Cocktails.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cocktails.API.DbContexts
{
    public class CocktailsDbContext : DbContext
    {
        public DbSet<Cocktail> Cocktails { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;

        public CocktailsDbContext(DbContextOptions<CocktailsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(

                new Ingredient("Cachaça") { Id = 1 },
                new Ingredient("Sugar") { Id = 2 },
                new Ingredient("Lime") { Id = 3 },
                new Ingredient("Absinthe") { Id = 4 },
                new Ingredient("Bénédictine") { Id = 5 },
                new Ingredient("Vermouth") { Id = 6 },
                new Ingredient("Gin") { Id = 7 },
                new Ingredient("Whisky") { Id = 8 },
                new Ingredient("Rum") { Id = 9 },
                new Ingredient("Port") { Id = 10 },

                new Ingredient("Brandy") { Id = 11 },
                new Ingredient("Stout") { Id = 12 },
                new Ingredient("Champagne") { Id = 13 },
                new Ingredient("Apricot") { Id = 14 },
                new Ingredient("Calvados") { Id = 15 },
                new Ingredient("White rum") { Id = 16 },
                new Ingredient("Cognac") { Id = 17 },
                new Ingredient("Triple sec") { Id = 18 },
                new Ingredient("Lemon juice") { Id = 19 },
                new Ingredient("Sweet vermouth") { Id = 20 },

                new Ingredient("Orange juice") { Id = 21 },
                new Ingredient("Sweetener") { Id = 22 },
                new Ingredient("Fernet-Branca") { Id = 23 },
                new Ingredient("Grenadine") { Id = 24 },
                new Ingredient("Vodka") { Id = 25 },
                new Ingredient("Grapefruit") { Id = 26 },
                new Ingredient("Peach brandy") { Id = 27 },
                new Ingredient("Heated sake") { Id = 28 },
                new Ingredient("Raw egg") { Id = 29 },
                new Ingredient("Tomato juice") { Id = 30 },

                new Ingredient("Worcestershire sauce") { Id = 31 },
                new Ingredient("Hot sauces") { Id = 32 },
                new Ingredient("Garlic") { Id = 33 },
                new Ingredient("Herbs") { Id = 34 },
                new Ingredient("Horseradish") { Id = 35 },
                new Ingredient("Celery") { Id = 36 },
                new Ingredient("Olives") { Id = 37 },
                new Ingredient("Pickled vegetables") { Id = 38 },
                new Ingredient("Salt") { Id = 39 },
                new Ingredient("Black pepper") { Id = 40 },

                new Ingredient("Lime juice") { Id = 41 },
                new Ingredient("Tequila") { Id = 42 },
                new Ingredient("Grapefruit-flavored soda") { Id = 43 },
                new Ingredient("Cola") { Id = 44 },
                new Ingredient("Mezcal") { Id = 45 },
                new Ingredient("Yellow Chartreuse") { Id = 46 },
                new Ingredient("Aperol") { Id = 47 },
                new Ingredient("Cranberry juice") { Id = 48 },
                new Ingredient("Grapefruit juice") { Id = 49 },
                new Ingredient("Elderflower cordial") { Id = 50 },

                new Ingredient("Honey syrup") { Id = 51 },
                new Ingredient("Red chili pepper") { Id = 52 },
                new Ingredient("Whiskey") { Id = 53 },
                new Ingredient("French vermouth (dry)") { Id = 54 },
                new Ingredient("Campari") { Id = 55 },
                new Ingredient("Tabasco sauce") { Id = 56 },

                new Ingredient("Lemonade") { Id = 57 },
                new Ingredient("Scotch whisky") { Id = 58 },
                new Ingredient("Drambuie") { Id = 59 }
                );

            modelBuilder.Entity<Cocktail>().HasData(

                new Cocktail("Caipirinha") { Id = 1 },
                new Cocktail("Chrysanthemum") { Id = 2 },
                new Cocktail("Hangman's Blood") { Id = 3 },
                new Cocktail("Angel Face") { Id = 4 },
                new Cocktail("Between the sheets") { Id = 5 },
                new Cocktail("Damn the weather") { Id = 6 },
                new Cocktail("Hanky panky") { Id = 7 },
                new Cocktail("Monkey Gland") { Id = 8 },
                new Cocktail("Salty dog") { Id = 9 },
                new Cocktail("Fish house punch") { Id = 10 },
                new Cocktail("Tamagozake") { Id = 11 },
                new Cocktail("Bloody Mary") { Id = 12 },
                new Cocktail("Paloma") { Id = 13 },
                new Cocktail("Batanga") { Id = 14 },
                new Cocktail("Margarita") { Id = 15 },
                new Cocktail("Naked and famous") { Id = 16 },
                new Cocktail("Screwdriver") { Id = 17 },
                new Cocktail("Sea breeze") { Id = 18 },
                new Cocktail("Spicy Fifty") { Id = 19 },
                new Cocktail("Old pal") { Id = 20 },
                new Cocktail("Amber moon") { Id = 21 },
                new Cocktail("Farnell") { Id = 22 },
                new Cocktail("Rusty nail") { Id = 23 }
               );

            modelBuilder
                .Entity<Cocktail>()
                .HasMany(d => d.Ingredients)
                .WithMany(i => i.Cocktails)
                .UsingEntity(e => e.HasData(

                    new { CocktailsId = 1, IngredientsId = 1 },
                    new { CocktailsId = 1, IngredientsId = 2 },
                    new { CocktailsId = 1, IngredientsId = 3 },

                    new { CocktailsId = 2, IngredientsId = 4 },
                    new { CocktailsId = 2, IngredientsId = 5 },
                    new { CocktailsId = 2, IngredientsId = 6 },

                    new { CocktailsId = 3, IngredientsId = 7 },
                    new { CocktailsId = 3, IngredientsId = 8 },
                    new { CocktailsId = 3, IngredientsId = 9 },
                    new { CocktailsId = 3, IngredientsId = 10 },
                    new { CocktailsId = 3, IngredientsId = 11 },
                    new { CocktailsId = 3, IngredientsId = 12 },
                    new { CocktailsId = 3, IngredientsId = 13 },

                    new { CocktailsId = 4, IngredientsId = 7 },
                    new { CocktailsId = 4, IngredientsId = 14 },
                    new { CocktailsId = 4, IngredientsId = 15 },

                    new { CocktailsId = 5, IngredientsId = 16 },
                    new { CocktailsId = 5, IngredientsId = 17 },
                    new { CocktailsId = 5, IngredientsId = 18 },
                    new { CocktailsId = 5, IngredientsId = 19 },

                    new { CocktailsId = 6, IngredientsId = 7 },
                    new { CocktailsId = 6, IngredientsId = 20 },
                    new { CocktailsId = 6, IngredientsId = 21 },
                    new { CocktailsId = 6, IngredientsId = 22 },

                    new { CocktailsId = 7, IngredientsId = 7 },
                    new { CocktailsId = 7, IngredientsId = 20 },
                    new { CocktailsId = 7, IngredientsId = 23 },

                    new { CocktailsId = 8, IngredientsId = 7 },
                    new { CocktailsId = 8, IngredientsId = 21 },
                    new { CocktailsId = 8, IngredientsId = 24 },
                    new { CocktailsId = 8, IngredientsId = 4 },

                    new { CocktailsId = 9, IngredientsId = 25 },
                    new { CocktailsId = 9, IngredientsId = 26 },

                    new { CocktailsId = 10, IngredientsId = 9 },
                    new { CocktailsId = 10, IngredientsId = 17 },
                    new { CocktailsId = 10, IngredientsId = 27 },

                    new { CocktailsId = 11, IngredientsId = 28 },
                    new { CocktailsId = 11, IngredientsId = 2 },
                    new { CocktailsId = 11, IngredientsId = 29 },

                    new { CocktailsId = 12, IngredientsId = 25 },
                    new { CocktailsId = 12, IngredientsId = 30 },
                    new { CocktailsId = 12, IngredientsId = 31 },
                    new { CocktailsId = 12, IngredientsId = 32 },
                    new { CocktailsId = 12, IngredientsId = 33 },
                    new { CocktailsId = 12, IngredientsId = 34 },
                    new { CocktailsId = 12, IngredientsId = 35 },
                    new { CocktailsId = 12, IngredientsId = 36 },
                    new { CocktailsId = 12, IngredientsId = 37 },
                    new { CocktailsId = 12, IngredientsId = 38 },
                    new { CocktailsId = 12, IngredientsId = 39 },
                    new { CocktailsId = 12, IngredientsId = 40 },
                    new { CocktailsId = 12, IngredientsId = 19 },
                    new { CocktailsId = 12, IngredientsId = 41 },

                    new { CocktailsId = 13, IngredientsId = 42 },
                    new { CocktailsId = 13, IngredientsId = 41 },
                    new { CocktailsId = 13, IngredientsId = 43 },

                    new { CocktailsId = 14, IngredientsId = 42 },
                    new { CocktailsId = 14, IngredientsId = 41 },
                    new { CocktailsId = 14, IngredientsId = 44 },

                    new { CocktailsId = 15, IngredientsId = 42 },
                    new { CocktailsId = 15, IngredientsId = 18 },
                    new { CocktailsId = 15, IngredientsId = 41 },

                    new { CocktailsId = 16, IngredientsId = 45 },
                    new { CocktailsId = 16, IngredientsId = 46 },
                    new { CocktailsId = 16, IngredientsId = 47 },
                    new { CocktailsId = 16, IngredientsId = 41 },

                    new { CocktailsId = 17, IngredientsId = 25 },
                    new { CocktailsId = 17, IngredientsId = 21 },

                    new { CocktailsId = 18, IngredientsId = 25 },
                    new { CocktailsId = 18, IngredientsId = 48 },
                    new { CocktailsId = 18, IngredientsId = 49 },

                    new { CocktailsId = 19, IngredientsId = 25 },
                    new { CocktailsId = 19, IngredientsId = 50 },
                    new { CocktailsId = 19, IngredientsId = 41 },
                    new { CocktailsId = 19, IngredientsId = 51 },
                    new { CocktailsId = 19, IngredientsId = 52 },

                    new { CocktailsId = 20, IngredientsId = 53 },
                    new { CocktailsId = 20, IngredientsId = 54 },
                    new { CocktailsId = 20, IngredientsId = 55 },

                    new { CocktailsId = 21, IngredientsId = 53 },
                    new { CocktailsId = 21, IngredientsId = 56 },
                    new { CocktailsId = 21, IngredientsId = 29 },

                    new { CocktailsId = 22, IngredientsId = 53 },
                    new { CocktailsId = 22, IngredientsId = 57 },

                    new { CocktailsId = 23, IngredientsId = 58 },
                    new { CocktailsId = 23, IngredientsId = 59 }
                    )
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
