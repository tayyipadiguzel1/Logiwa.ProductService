namespace Logiwa.ProductService.Application.Business.Products.Dtos;

/// <summary>
/// FilterProductDto
/// </summary>
public class FilterProductDto 
{
    public string SearchKey { get; set; }
    public int? MinStockQuantity { get; set; }
    public int? MaxStockQuantity { get; set; }
}