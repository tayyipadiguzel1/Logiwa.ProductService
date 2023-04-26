using FluentValidation.AspNetCore;
using Logiwa.ProductService.Application.Business.Products.Validations;

namespace Logiwa.ProductService.Application.Common.Extensions;

/// <summary>
/// ValidationExtensions
/// </summary>
public class ValidationExtensions
{
    public static void Register(FluentValidationMvcConfiguration fv)
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateProductValidation>();
        fv.RegisterValidatorsFromAssemblyContaining<UpdateProductValidator>();
    }
}