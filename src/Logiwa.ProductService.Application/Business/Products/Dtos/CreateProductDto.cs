namespace Logiwa.ProductService.Application.Business.Products.Dtos;

/// <summary>
/// CreateProductDto
/// </summary>
public class CreateProductDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public Guid? CategoryId { get; set; }
}