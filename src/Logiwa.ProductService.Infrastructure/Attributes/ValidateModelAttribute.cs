using Logiwa.ProductService.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Logiwa.ProductService.Infrastructure.Attributes;

/// <summary>
/// ValidateModelAttribute
/// </summary>
public class ValidateModelAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = context.ModelState.Result();
            return;
        }

        await next();
    }
}