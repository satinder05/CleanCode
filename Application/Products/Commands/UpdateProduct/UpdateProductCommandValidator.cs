using FluentValidation;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).MaximumLength(17);
            RuleFor(x => x.Description).MaximumLength(35);
            RuleFor(x => x.Price).LessThanOrEqualTo(9999.99M);
            RuleFor(x => x.DeliveryPrice).LessThanOrEqualTo(99.99M);
        }
    }
}
