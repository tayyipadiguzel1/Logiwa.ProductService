using AutoMapper;
using AutoMapper.QueryableExtensions;
using Logiwa.ProductService.Application.Business.Categories.Dtos;
using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using Logiwa.ProductService.Infrastructure.Handlers;
using Logiwa.ProductService.Infrastructure.Public.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logiwa.ProductService.Application.Business.Categories.Queries;

/// <summary>
/// GetCategoryQuery
/// </summary>
public class GetCategoryQuery : IRequest<ServiceResponse<CategoryDto>>
{
    public Guid Id { get; set; }
}

/// <summary>
/// GetCategoryHandler
/// </summary>
public class GetCategoryHandler : BaseHandler, IRequestHandler<GetCategoryQuery, ServiceResponse<CategoryDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    
    public GetCategoryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _uow.Categories.TableNoTracking
            .Where(a => a.Id == request.Id)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

       if(category is null) 
            return NoContent<CategoryDto>("category.not.found");

       return ServiceResponse(category);
    }
}