using FluentValidation;

namespace Application.Products.Queries
{
    public class GetProductDetailByNameQueryValidator : AbstractValidator<GetProductDetailByNameQuery>
    {
        public GetProductDetailByNameQueryValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(17);
        }
    }
}
