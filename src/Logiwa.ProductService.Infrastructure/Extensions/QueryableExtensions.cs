#nullable enable
using Logiwa.ProductService.Infrastructure.Interfaces;

namespace Logiwa.ProductService.Infrastructure.Extensions;

public static class QueryableExtensions
{
    /// <summary>
    /// Paging
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="current"></param>
    /// <param name="paging"></param>
    /// <param name="totalCount"></param>
    /// <returns></returns>
    public static IQueryable<T> Paging<T>(this IQueryable<T> current, IPaging? paging, out int totalCount)
    {
        totalCount = current.Count();
        if (paging is null)
            return current;

        if (paging.Page == 0 && paging.PageSize == 0)
        {
            paging.Page = 1;
            paging.PageSize = 50;
        }
        paging.Page = paging.Page <= 0 ? 1 : paging.Page;
        return current.Skip((paging.Page - 1) * paging.PageSize).Take(paging.PageSize);
    }
}