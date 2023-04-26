using Logiwa.ProductService.Infrastructure.Public.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Logiwa.ProductService.Infrastructure.Extensions;

/// <summary>
/// HttpExtensions
/// </summary>
public static class HttpExtensions
{
    /// <summary>
    /// NotValidResult
    /// </summary>
    /// <param name="modelState"></param>
    /// <returns></returns>
    public static IActionResult Result(this ModelStateDictionary modelState)
    {
        var validations = new SerializableError(modelState);
        var result = JsonConvert.SerializeObject(validations, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        var objectResult = JsonConvert.DeserializeObject(result);
        var messages = modelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList();
        var response = new ClientServiceResponse<object>(ClientResultCode.Validation, null, messages, objectResult);
        return new BadRequestObjectResult(response);
    }
}