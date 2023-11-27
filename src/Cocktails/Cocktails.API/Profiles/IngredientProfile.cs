using AutoMapper;

namespace Cocktails.API.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile() 
        {
            CreateMap<Entities.Ingredient, Models.IngredientWithoutCocktailsDto>();
            CreateMap<Entities.Ingredient, Models.IngredientDto>();
        }
    }
}
