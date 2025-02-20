using AutoMapper;
using Yummy.Api.Dtos.MessageDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class MessageMapping : Profile
{
    public MessageMapping()
    {   
        CreateMap<Message, ResultMessageDto>().ReverseMap();
        CreateMap<Message, CreateMessageDto>().ReverseMap();
        CreateMap<Message, UpdateMessageDto>().ReverseMap();
        CreateMap<Message, GetByIdMessageDto>().ReverseMap();
    }
}
