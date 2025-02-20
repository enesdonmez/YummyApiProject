using AutoMapper;
using Yummy.Api.Dtos.ContactDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<Contact, ResultContactDto>().ReverseMap();
        CreateMap<Contact, CreateContactDto>().ReverseMap();
        CreateMap<Contact, UpdateContactDto>().ReverseMap();
        CreateMap<Contact, GetByIdContactDto>().ReverseMap();
    }
}
