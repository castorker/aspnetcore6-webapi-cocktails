using AutoMapper;
using Cocktails.API.Models;

namespace Cocktails.API.Profiles
{
    public class CocktailProfile : Profile
    {
        public CocktailProfile()
        {
            CreateMap<Entities.Cocktail, Models.CocktailWithoutIngredientsDto>();
            CreateMap<Entities.Cocktail, Models.CocktailDto>();
            CreateMap<CocktailForCreationDto, Entities.Cocktail>();
            CreateMap<CocktailForUpdateDto, Entities.Cocktail>();
        }
    }
}
