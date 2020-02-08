using Application.ProductOptions.Commands.DeleteProductOption;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace Application.UnitTests.ProductOptions.Commands.Delete
{
    public class DeleteProductOptionCommandValidatorTests
    {
        private DeleteProductOptionCommandValidator _validator;

        public DeleteProductOptionCommandValidatorTests()
        {
            _validator = new DeleteProductOptionCommandValidator();
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
    }
}
