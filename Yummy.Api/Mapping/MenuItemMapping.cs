using AutoMapper;
using Yummy.Api.Dtos.MenuItemDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class MenuItemMapping : Profile
{
    public MenuItemMapping()
    {
        CreateMap<MenuItem, ResultMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, GetByIdMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap();
    }
}
