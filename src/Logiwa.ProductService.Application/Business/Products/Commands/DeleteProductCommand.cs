using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using Logiwa.ProductService.Infrastructure.Handlers;
using Logiwa.ProductService.Infrastructure.Public.Result;
using MediatR;

namespace Logiwa.ProductService.Application.Business.Products.Commands;

/// <summary>
/// DeleteProductCommand
/// </summary>
public class DeleteProductCommand : IRequest<ServiceResponse<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteProductHandler : BaseHandler, IRequestHandler<DeleteProductCommand, ServiceResponse<bool>>
{
    private readonly IUnitOfWork _uow;

    public DeleteProductHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<ServiceResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _uow.Products.FindAsync(a => a.Id == request.Id);
        if (product == null)
            return Warning<bool>("product not found");

        _uow.Products.Delete(product);
        await _uow.SaveChangesAsync();

        return ServiceResponse(true);
    }
}