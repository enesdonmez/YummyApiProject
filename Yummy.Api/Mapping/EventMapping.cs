using AutoMapper;
using Yummy.Api.Dtos.EventDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class EventMapping : Profile
{
    public EventMapping()
    {
        CreateMap<ResultEventDto, Event>().ReverseMap();
        CreateMap<CreateEventDto, Event>().ReverseMap();
        CreateMap<UpdateEventDto, Event>().ReverseMap();
        CreateMap<GetByIdEventDto, Event>().ReverseMap();
    }
}
