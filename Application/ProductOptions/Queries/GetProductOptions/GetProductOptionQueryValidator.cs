using FluentValidation;

namespace Application.ProductOptions.Queries.GetProductOptions
{
    public class GetProductOptionQueryValidator : AbstractValidator<GetProductOptionQuery>
    {
        public GetProductOptionQueryValidator()
        {
            RuleFor(x => x.ProductOptionId)
                .NotEmpty()
                .NotNull();
        }
    }
}
