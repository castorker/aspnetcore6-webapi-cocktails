using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cocktails.API.Entities
{
    public class Cocktail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public Cocktail(string name)
        {
            Name = name;
        }
    }
}
