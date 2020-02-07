using Application.ProductOptions.Commands.CreateProductOption;
using Application.UnitTests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Application.Common.Exceptions;

namespace Application.UnitTests.ProductOptions.Commands
{
    public class CreateProductOptionCommandTests : CommandTestBase
    {
        private CreateProductOptionCommandHandler _commandHandler;

        public CreateProductOptionCommandTests()
            : base()
        {
            _commandHandler = new CreateProductOptionCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateProductOption()
        {
            //Arrange
            var validRequest = new CreateProductOptionCommand
            {
                ProductId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"),
                Name = "Blue",
                Description = "Blue Samsung S9"
            };

            //Act
            var result = await _commandHandler.Handle(validRequest, CancellationToken.None);

            //Asert
            result.ShouldBeOfType<Guid>();
        }

        [Fact]
        public async Task Handle_WhenTryingToCreateOptionForNotExistingProduct_ThrowsNotFoundException()
        {
            //Arrange
            var request = new CreateProductOptionCommand
            {
                ProductId = new Guid(),
                Name = "Blue",
                Description = "Blue Samsung S9"
            };

            await Assert.ThrowsAsync<NotFoundException>(() => _commandHandler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenARequestWithValidProductIdWithoutNameAndDescription_ShouldCreateProductOption()
        {
            //Arrange
            var validRequest = new CreateProductOptionCommand
            {
                ProductId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"),
            };

            //Act
            var result = await _commandHandler.Handle(validRequest, CancellationToken.None);

            //Asert
            result.ShouldBeOfType<Guid>();
        }
    }
}
