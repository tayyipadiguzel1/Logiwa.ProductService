using AutoMapper;
using AutoMapper.QueryableExtensions;
using Logiwa.ProductService.Application.Business.Products.Commands;
using Logiwa.ProductService.Application.Business.Products.Dtos;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;
using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using Logiwa.ProductService.Infrastructure.Extensions;
using Logiwa.ProductService.Infrastructure.Handlers;
using Logiwa.ProductService.Infrastructure.Interfaces;
using Logiwa.ProductService.Infrastructure.Public;
using Logiwa.ProductService.Infrastructure.Public.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logiwa.ProductService.Application.Business.Products.Queries;

/// <summary>
/// ListProductQuery
/// </summary>
public class ListProductQuery : FilterProductDto, IPaging, IRequest<ServiceResponsePagination<ProductDto>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}

/// <summary>
/// ListProductHandler
/// </summary>
public class ListProductHandler : BaseHandler, IRequestHandler<ListProductQuery, ServiceResponsePagination<ProductDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ListProductHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<ServiceResponsePagination<ProductDto>> Handle(ListProductQuery request, CancellationToken cancellationToken)
    {
        var response = await Filter(request)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .Paging(request, out var totalCount)
            .ToListAsync(cancellationToken);

        return ServiceResponsePagination(response, new PaginationDto(totalCount, request.Page, request.PageSize));
    }

    private IQueryable<Product> Filter(FilterProductDto filter)
    {
        var query = _uow.Products.TableNoTracking.Include(a => a.Category).AsQueryable();

        if (!string.IsNullOrEmpty(filter.SearchKey))
            query = query.Where(x =>
                EF.Functions.ILike(x.Title, $"%{filter.SearchKey}%") ||
                EF.Functions.ILike(x.Description, $"%{filter.SearchKey}%") ||
                EF.Functions.ILike(x.Category.Name, $"%{filter.SearchKey}%"));

        if (filter.MinStockQuantity.HasValue)
            query = query.Where(x => x.StockQuantity > filter.MinStockQuantity.Value);

        if (filter.MaxStockQuantity.HasValue)
            query = query.Where(x => x.StockQuantity < filter.MaxStockQuantity.Value);

        return query;
    }
}