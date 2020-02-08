using Application.Products.Commands.UpdateProduct;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace Application.UnitTests.Products.Commands
{
    public class UpdateProductCommandValidatorTests
    {
        private UpdateProductCommandValidator _validator;
        public UpdateProductCommandValidatorTests()
        {
            _validator = new UpdateProductCommandValidator();
        }

        [Fact]
        public void Given_Empty_Id_WhenValidating_ShouldError()
        {
            Guid Id = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(product => product.Id, Id);
        }

        [Fact]
        public void Given_Valid_Id_WhenValidating_ShouldNotError()
        {
            Guid Id = Guid.NewGuid();
            _validator.ShouldNotHaveValidationErrorFor(product => product.Id, Id);
        }

        [Fact]
        public void Given_TooLongName_WhenValidating_ShouldError()
        {
            string tooLongName = "This is my too long name";
            _validator.ShouldHaveValidationErrorFor(product => product.Name, tooLongName);
        }

        [Fact]
        public void Given_ValidName_WhenValidating_ShouldNotError()
        {
            string validName = "Valid Name";
            _validator.ShouldNotHaveValidationErrorFor(product => product.Name, validName);
        }

        [Fact]
        public void Given_TooLongDescription_WhenValidating_ShouldError()
        {
            string tooLongDescription = "This is my super long product description";
            _validator.ShouldHaveValidationErrorFor(product => product.Description, tooLongDescription);
        }

        [Fact]
        public void Given_ValidDescription_WhenValidating_ShouldNotError()
        {
            string validDescription = "Valid Name";
            _validator.ShouldNotHaveValidationErrorFor(product => product.Description, validDescription);
        }

        [Fact]
        public void Given_TooBigPrice_WhenValidating_ShouldError()
        {
            decimal price = 99999.99m;
            _validator.ShouldHaveValidationErrorFor(product => product.Price, price);
        }

        [Fact]
        public void Given_ValidPrice_WhenValidating_ShouldNotError()
        {
            decimal price = 9000.99m;
            _validator.ShouldNotHaveValidationErrorFor(product => product.Price, price);
        }

        [Fact]
        public void Given_TooBigDeliveryPrice_WhenValidating_ShouldError()
        {
            decimal deliveryPrice = 200.99m;
            _validator.ShouldHaveValidationErrorFor(product => product.DeliveryPrice, deliveryPrice);
        }

        [Fact]
        public void Given_ValidDeliveryPrice_WhenValidating_ShouldNotError()
        {
            decimal deliveryPrice = 90.99m;
            _validator.ShouldNotHaveValidationErrorFor(product => product.DeliveryPrice, deliveryPrice);
        }
    }
}
