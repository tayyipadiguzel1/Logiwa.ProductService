using FluentValidation;
using Logiwa.ProductService.Application.Business.Products.Commands;
using MediatR;

namespace Logiwa.ProductService.Application.Business.Products.Validations;

/// <summary>
/// CreateProductValidation
/// </summary>
public class CreateProductValidation : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidation(ISender sender)
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