namespace Logiwa.ProductService.Infrastructure.Interfaces
{
    /// <summary>
    /// IPaging
    /// </summary>
    public interface IPaging
    {
        int Page { get; set; }
        int PageSize { get; set; }
    }
}
