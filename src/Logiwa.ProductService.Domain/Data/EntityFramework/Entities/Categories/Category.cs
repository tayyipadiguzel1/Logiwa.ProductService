using Logiwa.ProductService.Domain.EntityFrameWork.Entities;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories;

/// <summary>
/// Category
/// </summary>
public class Category : BaseEntity
{
    public string Name { get; set; }
}