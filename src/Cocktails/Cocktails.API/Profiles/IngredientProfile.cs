using AutoMapper;
using Cocktails.API.Models;

namespace Cocktails.API.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile() 
        {
            CreateMap<Entities.Ingredient, Models.IngredientWithoutCocktailsDto>();
            CreateMap<Entities.Ingredient, Models.IngredientDto>();
            CreateMap<Models.IngredientWithoutCocktailsDto, Entities.Ingredient>();
            CreateMap<IngredientForCreationDto, Entities.Ingredient>();
            CreateMap<IngredientForUpdateDto, Entities.Ingredient>();
            CreateMap<Entities.Ingredient, Models.IngredientForUpdateDto>();
        }
    }
}
