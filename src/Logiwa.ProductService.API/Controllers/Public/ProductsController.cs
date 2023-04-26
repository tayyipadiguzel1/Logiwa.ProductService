using Logiwa.ProductService.Application.Business.Products.Commands;
using Logiwa.ProductService.Application.Business.Products.Dtos;
using Logiwa.ProductService.Application.Business.Products.Queries;
using Logiwa.ProductService.Infrastructure.Attributes;
using Logiwa.ProductService.Infrastructure.Public;
using Microsoft.AspNetCore.Mvc;

namespace Logiwa.ProductService.API.Controllers.Public;

/// <summary>
/// ProductsController
/// </summary>
public class ProductsController : BaseController
{
    public ProductsController()
    {
        
    }
    
    /// <summary>
    /// Get a product.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    public async Task<IActionResult> Get([FromQuery] GetProductQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    
    /// <summary>
    /// List all products.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationList<ProductDto>))]
    public async Task<IActionResult> List([FromQuery] ListProductQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    
    /// <summary>
    /// Create a product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
    
    /// <summary>
    /// Create a product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
    
    /// <summary>
    /// Delete a product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }

}