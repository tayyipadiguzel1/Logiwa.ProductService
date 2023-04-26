using System.ComponentModel.DataAnnotations.Schema;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;
using Logiwa.ProductService.Domain.EntityFrameWork.Entities;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks;

/// <summary>
/// ProductCategoryStock
/// </summary>
public class ProductCategoryStock : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid CategoryId { get; set; }
    public int MinStockQuantity { get; set; }
    
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
}