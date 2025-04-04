using AutoMapper;
using Yummy.Api.Dtos.ImageDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class ImageMapping : Profile
{
    public ImageMapping()
    {
        CreateMap<Image, CreateImageDto>().ReverseMap();
        CreateMap<Image, GetImagetByIdDto>().ReverseMap();
        CreateMap<Image, UpdateImageDto>().ReverseMap();
        CreateMap<Image, ResultImageDto>().ReverseMap();
    }
}
