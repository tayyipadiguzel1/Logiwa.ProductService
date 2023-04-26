using AutoMapper;
using Logiwa.ProductService.Application.Business.Categories.Dtos;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories;

namespace Logiwa.ProductService.Application.Business.Categories.Mappings;

/// <summary>
/// CategoryMapping
/// </summary>
public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDto>();
    }
}