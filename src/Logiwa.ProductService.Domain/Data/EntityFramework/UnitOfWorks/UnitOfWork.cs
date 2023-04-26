using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;
using Logiwa.ProductService.Domain.Data.GenericRepositories;
using Logiwa.ProductService.Domain.EntityFrameWork.Entities;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;

/// <summary>
/// UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// SaveChanges
    /// </summary>
    /// <returns></returns>
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    /// <summary>
    /// SaveChangesAsync
    /// </summary>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }



    private GenericRepository<Product> _products;
    public GenericRepository<Product> Products => _products ??= T<Product>();
    
    private GenericRepository<Category> _categories;
    public GenericRepository<Category> Categories => _categories ??= T<Category>();
    
    private GenericRepository<ProductCategoryStock> _productCategoryStock;
    public GenericRepository<ProductCategoryStock> ProductCategoryStock => _productCategoryStock ??= T<ProductCategoryStock>();


    /// <summary>
    /// T
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public GenericRepository<TEntity> T<TEntity>() where TEntity : BaseEntity
    {
        var dbSet = _context.Set<TEntity>();
        return new GenericRepository<TEntity>(dbSet, _context);
    }


    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}