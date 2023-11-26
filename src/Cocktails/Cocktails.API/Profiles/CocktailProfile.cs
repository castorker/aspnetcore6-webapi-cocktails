using AutoMapper;

namespace Cocktails.API.Profiles
{
    public class CocktailProfile : Profile
    {
        public CocktailProfile()
        {
            CreateMap<Entities.Cocktail, Models.CocktailWithoutIngredientsDto>();
            CreateMap<Entities.Cocktail, Models.CocktailDto>();
        }
    }
}
