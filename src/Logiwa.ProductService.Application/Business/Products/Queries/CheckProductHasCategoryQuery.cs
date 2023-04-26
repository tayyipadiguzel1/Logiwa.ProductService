using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using MediatR;

namespace Logiwa.ProductService.Application.Business.Products.Queries;

/// <summary>
/// CheckProductHasCategoryQuery
/// </summary>
public class CheckProductHasCategoryQuery : IRequest<bool>
{
    public Guid ProductId { get; set; }
}

/// <summary>
/// CheckProductHasCategoryHandler
/// </summary>
public class CheckProductHasCategoryHandler : IRequestHandler<CheckProductHasCategoryQuery, bool>
{
    private readonly IUnitOfWork _uow;
    
    public CheckProductHasCategoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }
    
    public async Task<bool> Handle(CheckProductHasCategoryQuery request, CancellationToken cancellationToken)
    {
        var product = await _uow.Products.FindAsync(a => a.Id == request.ProductId);
        return product.CategoryId.HasValue;
    }
}