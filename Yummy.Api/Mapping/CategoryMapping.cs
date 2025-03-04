using AutoMapper;
using Yummy.Api.Dtos.CategoryDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
    }
}
