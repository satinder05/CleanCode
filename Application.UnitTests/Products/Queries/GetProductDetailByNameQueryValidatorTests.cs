using Application.Products.Queries;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.Products.Queries
{
    public class GetProductDetailByNameQueryValidatorTests
    {
        private GetProductDetailByNameQueryValidator _validator;
        public GetProductDetailByNameQueryValidatorTests()
        {
            _validator = new GetProductDetailByNameQueryValidator();
        }

        [Fact]
        public void Given_TooLongProductName_WhenValidating_ShouldError()
        {
            string tooLongName = "This is my too long name";
            _validator.ShouldHaveValidationErrorFor(product => product.ProductName, tooLongName);
        }

        [Fact]
        public void Given_ValidProductName_WhenValidating_ShouldNotError()
        {
            string validName = "Valid Name";
            _validator.ShouldNotHaveValidationErrorFor(product => product.ProductName, validName);
        }
    }
}
