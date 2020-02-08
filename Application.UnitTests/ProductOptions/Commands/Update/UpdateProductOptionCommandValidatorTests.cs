using Application.ProductOptions.Commands.UpdateProductOption;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Application.UnitTests.ProductOptions.Commands.Update
{
    public class UpdateProductOptionCommandValidatorTests
    {
        private UpdateProductOptionCommandValidator _validator;
        public UpdateProductOptionCommandValidatorTests()
        {
            _validator = new UpdateProductOptionCommandValidator();
        }

        [Fact]
        public void Given_Empty_OptionId_WhenValidating_ShouldError()
        {
            Guid optionId = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(option => option.Id, optionId);
        }

        [Fact]
        public void Given_Valid_OptionId_WhenValidating_ShouldNotError()
        {
            Guid optionId = Guid.NewGuid();
            _validator.ShouldNotHaveValidationErrorFor(option => option.Id, optionId);
        }

        [Fact]
        public void Given_TooLongName_WhenValidating_ShouldError()
        {
            string tooLongName = "This is my too long name";
            _validator.ShouldHaveValidationErrorFor(option => option.Name, tooLongName);
        }

        [Fact]
        public void Given_ValidName_WhenValidating_ShouldNotError()
        {
            string validName = "Option";
            _validator.ShouldNotHaveValidationErrorFor(option => option.Name, validName);
        }

        [Fact]
        public void Given_TooLongDescription_WhenValidating_ShouldError()
        {
            string tooLongDescription = "This is my long product Option";
            _validator.ShouldHaveValidationErrorFor(option => option.Description, tooLongDescription);
        }

        [Fact]
        public void Given_ValidDescription_WhenValidating_ShouldNotError()
        {
            string validDescription = "Valid Option";
            _validator.ShouldNotHaveValidationErrorFor(option => option.Description, validDescription);
        }
    }
}
