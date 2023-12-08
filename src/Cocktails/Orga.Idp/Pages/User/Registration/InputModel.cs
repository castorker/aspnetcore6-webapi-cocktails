using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Orga.Idp.Pages.User.Registration
{
    public class InputModel
    {
        public string ReturnUrl { get; set; }

        [MaxLength(200)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [MaxLength(200)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Given name")]
        public string GivenName { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Family name")]
        public string FamilyName { get; set; }

        [Required]
        [MaxLength(2)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public SelectList CountryCodes { get; set; } =
            new(new[] {
                    new { Id = "pt", Value = "Portugal" },
                    new { Id = "nl", Value = "the Netherlands" },
                    new { Id = "br", Value = "Brazil" } },
                "Id",
                "Value");
    }
}
