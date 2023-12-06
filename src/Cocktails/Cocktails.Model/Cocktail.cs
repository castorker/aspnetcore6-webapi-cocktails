namespace Cocktails.Model
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfIngredients
        {
            get
            {
                return Ingredients.Count;
            }
        }

        public ICollection<IngredientWithoutCocktails> Ingredients { get; set; } = new List<IngredientWithoutCocktails>();
    }
}
