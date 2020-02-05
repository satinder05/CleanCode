using FluentValidation;

namespace Application.ProductOptions.Commands.DeleteProductOption
{
    public class DeleteProductOptionCommandValidator : AbstractValidator<DeleteProductOptionCommand>
    {
        public DeleteProductOptionCommandValidator()
        {
            RuleFor(x => x.ProductOptionId)
                .NotEmpty()
                .NotNull();
        }
    }
}
