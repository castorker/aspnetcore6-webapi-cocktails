using Cocktails.Model;

namespace Cocktails.Client.ViewModels
{
    public class CocktailsIndexViewModel
    {
        public IEnumerable<CocktailWithoutIngredients> Cocktails { get; private set; }
            = new List<CocktailWithoutIngredients>();

        public CocktailsIndexViewModel(IEnumerable<CocktailWithoutIngredients> cocktails)
        {
            Cocktails = cocktails;
        }
    }
}
