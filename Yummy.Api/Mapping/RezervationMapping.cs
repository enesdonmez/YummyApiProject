using AutoMapper;
using Yummy.Api.Dtos.RezervationDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class RezervationMapping : Profile
{
    public RezervationMapping()
    {
        CreateMap<Reservation, ResultRezervationDto>().ReverseMap();
        CreateMap<Reservation, CreateRezervationDto>().ReverseMap();
        CreateMap<Reservation, UpdateRezervationDto>().ReverseMap();
        CreateMap<Reservation, GetByIdRezervationDto>().ReverseMap();
    }
}

