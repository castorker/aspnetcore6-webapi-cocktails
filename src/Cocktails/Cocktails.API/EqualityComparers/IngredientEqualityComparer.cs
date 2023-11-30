using Cocktails.API.Entities;
using Cocktails.API.Models;
using System.Diagnostics.CodeAnalysis;

namespace Cocktails.API.EqualityComparers
{
    public class IngredientEqualityComparer : EqualityComparer<IngredientWithoutCocktailsDto>
    {
        private static readonly IngredientEqualityComparer _instance = new IngredientEqualityComparer();

        public static IngredientEqualityComparer Instance { get { return _instance; } }

        private IngredientEqualityComparer() { }

        public override bool Equals(IngredientWithoutCocktailsDto x, IngredientWithoutCocktailsDto y)
        {
            return x.Id == y.Id
                && x.Name.ToUpperInvariant() == y.Name.ToUpperInvariant();
        }

        public override int GetHashCode([DisallowNull] IngredientWithoutCocktailsDto obj)
        {
            return obj.Id.GetHashCode() ^
                obj.Name.ToUpperInvariant().GetHashCode();
        }
    }
}
