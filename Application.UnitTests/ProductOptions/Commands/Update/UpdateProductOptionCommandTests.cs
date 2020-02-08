using Application.ProductOptions.Commands.UpdateProductOption;
using Application.UnitTests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Application.Common.Exceptions;

namespace Application.UnitTests.ProductOptions.Commands
{
    public class UpdateProductOptionCommandTests : CommandTestBase
    {
        private UpdateProductOptionCommandHandler _commandHandler;

        public UpdateProductOptionCommandTests()
            : base()
        {
            _commandHandler = new UpdateProductOptionCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenExistingProductOption_WhenUpdatingWithAValidName_ShouldUpdateOptionName()
        {
            // Arrange
            string newOptionName = "New Option";
            UpdateProductOptionCommand request = new UpdateProductOptionCommand 
            { 
                Id = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4905"), 
                Name = newOptionName,
                Description = "White Samsung S10"
            };

            //Act
            var result = await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Name.ShouldBe(newOptionName);
        }

        [Fact]
        public async Task Handle_GivenExistingProductOption_WhenUpdatingWithAValidDescription_ShouldUpdateOptionDescription()
        {
            // Arrange
            string newOptionDescription = "New Description";
            UpdateProductOptionCommand request = new UpdateProductOptionCommand
            {
                Id = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4905"),
                Name = "White",
                Description = newOptionDescription
            };

            //Act
            var result = await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Description.ShouldBe(newOptionDescription);
        }

        [Fact]
        public async Task Handle_WhenTryingToUpdateNotExistingProductOptionId_ThrowsNotFoundException()
        {
            UpdateProductOptionCommand request = new UpdateProductOptionCommand
            {
                Id = new Guid(),
                Name = "White",
                Description = "White Samsung S10"
            };

            await Assert.ThrowsAsync<NotFoundException>(() => _commandHandler.Handle(request, CancellationToken.None));
        }
    }
}
