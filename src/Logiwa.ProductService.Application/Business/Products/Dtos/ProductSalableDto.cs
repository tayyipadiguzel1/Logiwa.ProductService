namespace Logiwa.ProductService.Application.Business.Products.Dtos;

/// <summary>
/// ProductSalableDto
/// </summary>
public class ProductSalableDto
{
    public Guid Id { get; set; }
    public bool IsSalable { get; set; }
}