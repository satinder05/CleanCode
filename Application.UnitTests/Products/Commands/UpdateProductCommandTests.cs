using Application.Products.Commands.UpdateProduct;
using Application.UnitTests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Application.Common.Exceptions;

namespace Application.UnitTests.Products.Commands
{
    public class UpdateProductCommandTests : CommandTestBase
    {
        private UpdateProductCommandHandler _commandHandler;

        public UpdateProductCommandTests()
            : base()
        {
            _commandHandler = new UpdateProductCommandHandler(_context);
        }   

        [Fact]
        public async Task Handle_GivenExistingProduct_WhenUpdatingWithAValidName_ShouldUpdateProductName()
        {
            // Arrange
            string newProductName = "New Product Name";
            UpdateProductCommand request = new UpdateProductCommand
            {
                Id = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"),
                Name = newProductName,
                Description = "Older mobile from Samsung.",
                Price = 700.99M,
                DeliveryPrice = 20.99M
            };

            //Act
            var result = await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Name.ShouldBe(newProductName);
        }

        [Fact]
        public async Task Handle_GivenExistingProduct_WhenUpdatingWithAValidDescription_ShouldUpdateProductDescription()
        {
            // Arrange
            string newProductDescription = "New Description";
            UpdateProductCommand request = new UpdateProductCommand
            {
                Id = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"),
                Name = "Samsung Galaxy S9",
                Description = newProductDescription,
                Price = 700.99M,
                DeliveryPrice = 20.99M
            };

            //Act
            var result = await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Description.ShouldBe(newProductDescription);
        }

        [Fact]
        public async Task Handle_GivenExistingProduct_WhenUpdatingWithAValidPrice_ShouldUpdateProductPrice()
        {
            // Arrange
            decimal newProductPrice = 655.99M;
            UpdateProductCommand request = new UpdateProductCommand
            {
                Id = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"),
                Name = "Samsung Galaxy S9",
                Description = "Older mobile from Samsung.",
                Price = newProductPrice,
                DeliveryPrice = 20.99M
            };

            //Act
            var result = await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Price.ShouldBe(newProductPrice);
        }

        [Fact]
        public async Task Handle_GivenExistingProduct_WhenUpdatingWithAValidDeliveryPrice_ShouldUpdateProductDeliveryPrice()
        {
            // Arrange
            decimal newDeliveryPrice = 12.99M;
            UpdateProductCommand request = new UpdateProductCommand
            {
                Id = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"),
                Name = "Samsung Galaxy S9",
                Description = "Older mobile from Samsung.",
                Price = 700.99M,
                DeliveryPrice = newDeliveryPrice
            };

            //Act
            var result = await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            result.DeliveryPrice.ShouldBe(newDeliveryPrice);
        }

        [Fact]
        public async Task Handle_WhenTryingToUpdateWithNotExistingId_ThrowsNotFoundException()
        {
            UpdateProductCommand request = new UpdateProductCommand
            {
                Id = new Guid(),
                Name = "Samsung Galaxy S9",
                Description = "Older mobile from Samsung.",
                Price = 700.99M,
                DeliveryPrice = 20.99M
            };

            await Assert.ThrowsAsync<NotFoundException>(() => _commandHandler.Handle(request, CancellationToken.None));
        }
    }
}
