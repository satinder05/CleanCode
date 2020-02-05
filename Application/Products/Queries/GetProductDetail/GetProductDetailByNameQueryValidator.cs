using FluentValidation;

namespace Application.Products.Queries.GetProductDetail
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
