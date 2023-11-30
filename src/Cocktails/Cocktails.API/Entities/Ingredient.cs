using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Cocktails.API.Models.Interfaces;

namespace Cocktails.API.Entities
{
    public class Ingredient : IDataEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public virtual ICollection<Cocktail> Cocktails { get; set; } = new List<Cocktail>();

        public Ingredient(string name)
        {
            Name = name;
        }
    }
}
