using System.Linq.Expressions;
using Logiwa.ProductService.Domain.Data.EntityFramework;
using Logiwa.ProductService.Domain.EntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logiwa.ProductService.Domain.Data.GenericRepositories;

public class GenericRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;
    private readonly DataContext _dataContext;
    
    public GenericRepository(DbSet<T> dbSet, DataContext dataContext)
    {
        _dbSet = dbSet;
        _dataContext = dataContext;
    }
    
    /// <summary>
    /// List
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual IQueryable<T> List(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    /// <summary>
    /// List
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual IQueryable<T> ListNt(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate);
    }
    
     /// <summary>
        /// Any
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).Any();
        }

        /// <summary>
        /// AnyAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AnyAsync();
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Find(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// FindAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        public virtual T Create(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            var result = _dbSet.Add(entity);
            return result.Entity;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="entity"></param>
        public virtual T Edit(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Attach(entity);
            return entity;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity">Kayıt</param>
        public virtual void Delete(T entity)
        {
            entity.Deleted = true;
            entity.DeletedAt = DateTime.UtcNow;
            Edit(entity);
        }

        /// <summary>
        /// ForceDelete
        /// </summary>
        /// <param name="entity">Kayıt</param>
        public virtual void ForceDelete(T entity)
        {
            _dbSet.Remove(entity);
        }
        
        /// <summary>
        /// ForceDeleteRange
        /// </summary>
        /// <param name="entities"></param>
        public virtual void ForceDeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// RemoveRange
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual void RemoveRange(List<T> entities)
        {
            if (entities.Any())
            {
                foreach (var entity in entities)
                {
                    entity.Deleted = true;
                    entity.DeletedAt = DateTime.UtcNow;
                }
                _dbSet.UpdateRange(entities);
            }
        } 
        
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }
        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table => this._dbSet;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking => this._dbSet.AsNoTracking();

        #endregion
}