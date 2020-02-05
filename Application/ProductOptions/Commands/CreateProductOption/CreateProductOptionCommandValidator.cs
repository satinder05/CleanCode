using FluentValidation;

namespace Application.ProductOptions.Commands.CreateProductOption
{
    public class CreateProductOptionCommandValidator : AbstractValidator<CreateProductOptionCommand>
    {
        public CreateProductOptionCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().NotNull();
            RuleFor(x => x.Name).MaximumLength(9);
            RuleFor(x => x.Description).MaximumLength(23);
        }
    }
}
