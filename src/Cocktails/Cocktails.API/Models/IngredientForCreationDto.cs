using System.ComponentModel.DataAnnotations;

namespace Cocktails.API.Models
{
    public class IngredientForCreationDto
    {
        [Required(ErrorMessage = "You should provide a value for name.")]
        [MaxLength(50, ErrorMessage = "Ingredient name must not exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000, ErrorMessage = "Ingredient description must be no longer than 1000 characters.")]
        public string? Description { get; set; }

    }
}
