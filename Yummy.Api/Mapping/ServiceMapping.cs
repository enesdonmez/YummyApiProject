using AutoMapper;
using Yummy.Api.Dtos.ServiceDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class ServiceMapping : Profile
{
    public ServiceMapping()
    {
        CreateMap<Service, ResultServiceDto>().ReverseMap();
        CreateMap<Service, CreateServiceDto>().ReverseMap();
        CreateMap<Service, UpdateServiceDto>().ReverseMap();
        CreateMap<Service, GetByIdServiceDto>().ReverseMap();
    }
}
