using AutoMapper;
using Yummy.Api.Dtos.FeatureDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class FeatureMapping : Profile
{
    public FeatureMapping()
    {
        CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature, ResulFeatureDto>().ReverseMap();
    }
}
