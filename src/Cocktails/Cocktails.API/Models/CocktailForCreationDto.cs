﻿using System.ComponentModel.DataAnnotations;

namespace Cocktails.API.Models
{
    public class CocktailForCreationDto
    {
        [Required(ErrorMessage = "You should provide a value for name.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
