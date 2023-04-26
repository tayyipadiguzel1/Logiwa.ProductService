using Logiwa.ProductService.Application.Business.Products.Dtos;
using Logiwa.ProductService.Application.Business.Products.Queries;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;
using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using Logiwa.ProductService.Infrastructure.Handlers;
using Logiwa.ProductService.Infrastructure.Public.Result;
using MediatR;

namespace Logiwa.ProductService.Application.Business.Products.Commands;

/// <summary>
/// UpdateProductCommand
/// </summary>
public class UpdateProductCommand : UpdateProductDto
{
}

/// <summary>
/// UpdateProductHandler
/// </summary>
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<ProductDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;

    public UpdateProductHandler(IUnitOfWork uow, ISender sender)
    {
        _uow = uow;
        _sender = sender;
    }

    public async Task<ServiceResponse<ProductDto>> Handle(UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _uow.Products.FindAsync(a => a.Id == request.Id);

        product.CategoryId = request.CategoryId;
        product.Title = request.Title;
        product.Description = request.Description;

        _uow.Products.Edit(product);
        await _uow.SaveChangesAsync();

        var result = await _sender.Send(new GetProductQuery() {Id = product.Id}, cancellationToken);
        return result;
    }
}