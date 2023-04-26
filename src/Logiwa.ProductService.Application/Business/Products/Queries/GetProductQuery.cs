using AutoMapper;
using AutoMapper.QueryableExtensions;
using Logiwa.ProductService.Application.Business.Products.Dtos;
using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using Logiwa.ProductService.Infrastructure.Handlers;
using Logiwa.ProductService.Infrastructure.Public.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logiwa.ProductService.Application.Business.Products.Queries;

/// <summary>
/// GetProductQuery
/// </summary>
public class GetProductQuery : IRequest<ServiceResponse<ProductDto>>
{
    public Guid Id { get; set; }    
}

/// <summary>
/// GetProductHandler
/// </summary>
public class GetProductHandler : BaseHandler, IRequestHandler<GetProductQuery, ServiceResponse<ProductDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    
    public GetProductHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<ServiceResponse<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _uow.Products.TableNoTracking.Where(a => a.Id == request.Id)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
            return NoContent<ProductDto>("product.not.found");
        
        return ServiceResponse(product);
    }
}