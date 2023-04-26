using Logiwa.ProductService.Application.Business.Categories.Dtos;
using Logiwa.ProductService.Application.Business.Categories.Queries;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories;
using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using Logiwa.ProductService.Infrastructure.Public.Result;
using MediatR;

namespace Logiwa.ProductService.Application.Business.Categories.Commands;

/// <summary>
/// CreateCategoryCommand
/// </summary>
public class CreateCategoryCommand : CreateCategoryDto, IRequest<ServiceResponse<CategoryDto>>
{
    
}

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse<CategoryDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    
    public CreateCategoryHandler(IUnitOfWork uow, ISender sender)
    {
        _uow = uow;
        _sender = sender;
    }
    
    public async Task<ServiceResponse<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category()
        {
            Name = request.Name
        };

        _uow.Categories.Create(category);
        await _uow.SaveChangesAsync();

        var result = await _sender.Send(new GetCategoryQuery() {Id = category.Id}, cancellationToken);
        return result;
    }
}