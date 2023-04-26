using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;
using Logiwa.ProductService.Domain.Data.GenericRepositories;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;

/// <summary>
/// IUnitOfWorks
/// </summary>
public interface IUnitOfWork : IDisposable
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
    
    
    GenericRepository<Product> Products { get; }
    GenericRepository<Category> Categories { get; }
    GenericRepository<ProductCategoryStock> ProductCategoryStock { get; }
   
}