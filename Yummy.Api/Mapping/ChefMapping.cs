using AutoMapper;
using Yummy.Api.Dtos.ChefDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class ChefMapping : Profile
{
    public ChefMapping()
    {
        CreateMap<Chef, ResultChefDto>().ReverseMap();
        CreateMap<Chef, CreateChefDto>().ReverseMap();
        CreateMap<Chef, UpdateChefDto>().ReverseMap();
        CreateMap<Chef, GetByIdChefDto>().ReverseMap();
    }
}
