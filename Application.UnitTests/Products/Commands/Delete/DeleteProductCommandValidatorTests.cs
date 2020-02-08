using Application.Products.Commands.DeleteProduct;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace Application.UnitTests.Products.Commands
{
    public class DeleteProductCommandValidatorTests
    {
        private DeleteProductCommandValidator _validator;
        public DeleteProductCommandValidatorTests()
        {
            _validator = new DeleteProductCommandValidator();
        }

        [Fact]
        public void Given_Empty_ProductId_WhenValidating_ShouldError()
        {
            Guid productId = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(product => product.ProductId, productId);
        }

        [Fact]
        public void Given_Valid_ProductId_WhenValidating_ShouldNotError()
        {
            Guid productId = Guid.NewGuid();
            _validator.ShouldNotHaveValidationErrorFor(product => product.ProductId, productId);
        }
    }
}
