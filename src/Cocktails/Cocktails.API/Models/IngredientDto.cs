namespace Cocktails.API.Models
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfCocktails
        {
            get
            {
                return Cocktails.Count;
            }
        }

        public ICollection<CocktailWithoutIngredientsDto> Cocktails { get; set; } = new List<CocktailWithoutIngredientsDto>();
    }
}
