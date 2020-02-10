using Application.ProductOptions.Queries.GetProductOptions;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace Application.UnitTests.ProductOptions.Queries
{
    public class GetProductOptionQueryValidatorTests
    {
        private GetProductOptionQueryValidator _validator;

        public GetProductOptionQueryValidatorTests()
        {
            _validator = new GetProductOptionQueryValidator();
        }

        [Fact]
        public void Given_Empty_OptionId_WhenValidating_ShouldError()
        {
            Guid optionId = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(option => option.ProductOptionId, optionId);
        }

        [Fact]
        public void Given_Valid_OptionId_WhenValidating_ShouldNotError()
        {
            Guid optionId = Guid.NewGuid();
            _validator.ShouldNotHaveValidationErrorFor(option => option.ProductOptionId, optionId);
        }

        [Fact]
        public void Given_Empty_ProductId_WhenValidating_ShouldError()
        {
            Guid productId = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(option => option.ProductOptionId, productId);
        }

        [Fact]
        public void Given_Valid_ProductId_WhenValidating_ShouldNotError()
        {
            Guid productId = Guid.NewGuid();
            _validator.ShouldNotHaveValidationErrorFor(option => option.ProductOptionId, productId);
        }
    }
}
