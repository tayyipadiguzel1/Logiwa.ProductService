using AutoMapper;
using Logiwa.ProductService.Application.Business.Products.Dtos;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;

namespace Logiwa.ProductService.Application.Business.Products.Mappings;

/// <summary>
/// ProductMapping
/// </summary>
public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductDto>()
        .ForMember(a => a.IsSalable,  opt => opt.MapFrom(src =>
                src.CategoryId.HasValue && src.ProductCategoryStock!.MinStockQuantity > src.StockQuantity));

    }
}