using Application.Products.Commands.CreateProduct;
using Application.UnitTests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace Application.UnitTests.Products.Commands
{
    public class CreateProductCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateProduct()
        {
            //Arrange
            CreateProductCommand request = new CreateProductCommand { Name = "Test Product", Description = "First Test Product", Price = 200.55m, DeliveryPrice = 20 };
            var handler = new CreateProductCommandHandler(_context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<Guid>();
        }

        [Fact]
        public async Task Handle_GivenAnEmptyRequest_ShouldCreateProduct()
        {
            //Arrange
            CreateProductCommand request = new CreateProductCommand { };
            var handler = new CreateProductCommandHandler(_context);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<Guid>();
        }
    }
}
