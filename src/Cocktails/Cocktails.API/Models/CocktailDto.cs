namespace Cocktails.API.Models
{
    public class CocktailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfIngredients
        {
            get
            {
                return Ingredients.Count;
            }
        }

        public ICollection<IngredientWithoutCocktailsDto> Ingredients { get; set; } = new List<IngredientWithoutCocktailsDto>();
    }
}
