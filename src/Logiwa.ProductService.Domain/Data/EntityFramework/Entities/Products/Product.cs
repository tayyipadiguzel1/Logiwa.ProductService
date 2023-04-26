using System.ComponentModel.DataAnnotations.Schema;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks;
using Logiwa.ProductService.Domain.EntityFrameWork.Entities;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;

/// <summary>
/// Product
/// </summary>
public class Product : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public Guid? CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
    
    public virtual  ProductCategoryStock ProductCategoryStock { get; set; }
}