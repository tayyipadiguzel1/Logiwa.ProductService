using Logiwa.ProductService.Application.Business.Products.Dtos;
using Logiwa.ProductService.Application.Business.Products.Queries;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;
using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using Logiwa.ProductService.Infrastructure.Public.Result;
using MediatR;

namespace Logiwa.ProductService.Application.Business.Products.Commands;

/// <summary>
/// 
/// </summary>
public class CreateProductCommand : CreateProductDto, IRequest<ServiceResponse<ProductDto>>
{
}

/// <summary>
/// CreateProductHandler
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, ServiceResponse<ProductDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;

    public CreateProductHandler(IUnitOfWork uow, ISender sender)
    {
        _uow = uow;
        _sender = sender;
    }

    public async Task<ServiceResponse<ProductDto>> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Title = request.Title,
            Description = request.Description,
            CategoryId = request.CategoryId,
            StockQuantity = request.StockQuantity < 0 ? 0 : request.StockQuantity
        };

        _uow.Products.Create(product);
        await _uow.SaveChangesAsync();
        
        var result = await _sender.Send(new GetProductQuery {Id = product.Id}, cancellationToken);
        return result;
    }
}