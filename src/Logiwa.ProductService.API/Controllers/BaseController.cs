using Logiwa.ProductService.Infrastructure.Enums;
using Logiwa.ProductService.Infrastructure.Public.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Logiwa.ProductService.API.Controllers;

[Produces("application/json")]
[Route("api/[controller]/[action]")]
public class BaseController : Controller
{
    private IMediator _mediator;

    protected IMediator Mediator
        => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


    /// <summary>
    /// Ok
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="response"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Ok<T>(ServiceResponse<T> response)
    {
        switch (response.ResultCode)
        {
            case ResultCode.Success:
                return base.Ok(response.Result);
        }

        return HandleClientStatusCode(response);
    }


    /// <summary>
    /// HandleClientStatusCode
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    private IActionResult HandleClientStatusCode(ServiceResponse response)
    {
        switch (response.ResultCode)
        {
            case ResultCode.Success:
                return base.Ok(response.Success);
            case ResultCode.Exception:
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ClientServiceResponse(ClientResultCode.Error, response.Title, response.ResultMessage));
            case ResultCode.AuthorizationError:
                return StatusCode(StatusCodes.Status401Unauthorized,
                    new ClientServiceResponse(ClientResultCode.Authorization, response.Title, response.ResultMessage));
            case ResultCode.NoContent:
                return StatusCode(StatusCodes.Status204NoContent);
            case ResultCode.Warning:
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ClientServiceResponse(ClientResultCode.Warning, response.Title, response.ResultMessage));
            case ResultCode.ValidationError:
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ClientServiceResponse(ClientResultCode.Validation, response.Title, response.ResultMessage));
            default:
                return StatusCode(StatusCodes.Status400BadRequest, new ClientServiceResponse(ClientResultCode.Warning, response.Title, response.ResultMessage));

        }
    }

}