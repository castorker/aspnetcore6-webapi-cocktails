using System.ComponentModel.DataAnnotations;

namespace Cocktails.Client.ViewModels
{
    public class EditCocktailViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public int Id { get; set; }

        public string? Ingredients { get; set; }
    }
}
