using FluentValidation;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(17);
            RuleFor(x => x.Description).MaximumLength(35);
            RuleFor(x => x.Price).LessThanOrEqualTo(9999.99M);
            RuleFor(x => x.DeliveryPrice).LessThanOrEqualTo(99.99M);
        }
    }
}
