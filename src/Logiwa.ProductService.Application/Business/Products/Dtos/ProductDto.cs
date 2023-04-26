using Logiwa.ProductService.Application.Business.Categories.Dtos;
using Logiwa.ProductService.Application.Common;

namespace Logiwa.ProductService.Application.Business.Products.Dtos;

/// <summary>
/// ProductDto
/// </summary>
public class ProductDto : BaseDto
{
    public ProductDto()
    {
        Category = new CategoryDto();
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public bool IsSalable { get; set; }
    public CategoryDto Category { get; set; }
}