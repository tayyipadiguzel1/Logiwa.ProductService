namespace Logiwa.ProductService.Infrastructure.Enums;

/// <summary>
/// ResultCode
/// </summary>
public enum ResultCode
{
    Exception = 0,
    Success = 1,
    ValidationError = 2,
    AuthorizationError = 3,
    NoContent = 4,
    Warning = 5
}