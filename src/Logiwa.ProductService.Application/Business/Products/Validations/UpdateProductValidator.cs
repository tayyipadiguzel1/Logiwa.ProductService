using FluentValidation;
using Logiwa.ProductService.Application.Business.Products.Commands;
using MediatR;

namespace Logiwa.ProductService.Application.Business.Products.Validations;

/// <summary>
/// UpdateProductValidation
/// </summary>
public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator(ISender sender)
    {
        RuleFor(x => x.Title)
            .NotNull()
            .WithMessage($"Title can not be null.")
            .NotEmpty()
            .WithMessage($"Title can not be empty.")
            .MaximumLength(200)
            .WithMessage("The title can be up to 200 characters");
    }
}