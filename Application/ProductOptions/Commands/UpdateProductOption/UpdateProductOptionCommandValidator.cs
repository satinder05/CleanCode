using FluentValidation;

namespace Application.ProductOptions.Commands.UpdateProductOption
{
    public class UpdateProductOptionCommandValidator : AbstractValidator<UpdateProductOptionCommand>
    {
        public UpdateProductOptionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).MaximumLength(9);
            RuleFor(x => x.Description).MaximumLength(23);
        }
    }
}
