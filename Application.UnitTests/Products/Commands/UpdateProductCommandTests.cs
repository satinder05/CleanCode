using Application.Products.Commands.UpdateProduct;
using Application.UnitTests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;


namespace Application.UnitTests.Products.Commands
{
    public class UpdateProductCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenExistingProduct_WhenUpdatingWithAValidName_ShouldUpdateProductName()
        {
            // Arrange
            UpdateProductCommand request = new UpdateProductCommand {Id = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"), Name = "Test Product", Description = "First Test Product", Price = 200.55m, DeliveryPrice = 20 };
            var handler = new UpdateProductCommandHandler(_context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.Name.ShouldBe("Test Product");
        }
    }
}
