using Logiwa.ProductService.Application.Business.Products.Commands;

namespace Logiwa.ProductService.Application.Business.Products.Dtos;

/// <summary>
/// UpdateProductDto
/// </summary>
public class UpdateProductDto : CreateProductCommand
{
    public Guid Id { get; set; }
}