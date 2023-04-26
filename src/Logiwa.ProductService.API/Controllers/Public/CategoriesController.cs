using Logiwa.ProductService.Application.Business.Categories.Commands;
using Logiwa.ProductService.Application.Business.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Logiwa.ProductService.API.Controllers.Public;

/// <summary>
/// CategoriesController
/// </summary>
public class CategoriesController : BaseController
{
    public CategoriesController()
    {
        
    }
    
    /// <summary>
    /// Get a product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
    
}