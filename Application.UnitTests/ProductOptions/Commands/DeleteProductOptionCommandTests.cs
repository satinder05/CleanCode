using Application.ProductOptions.Commands.DeleteProductOption;
using Application.UnitTests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Application.Common.Exceptions;

namespace Application.UnitTests.ProductOptions.Commands
{
    public class DeleteProductOptionCommandTests : CommandTestBase
    {
        private DeleteProductOptionCommandHandler _commandHandler;
        public DeleteProductOptionCommandTests()
            :base()
        {
            _commandHandler = new DeleteProductOptionCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_WhenTryingToDeleteNotExistingProductOptionId_ThrowsNotFoundException()
        {
            DeleteProductOptionCommand request = new DeleteProductOptionCommand 
            { 
                ProductOptionId = new Guid() 
            };

            await Assert.ThrowsAsync<NotFoundException>(() => _commandHandler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidProductOptionId_ShouldDeleteProductOption()
        {
            //Arrange
            var validProductOptionId = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4905");

            DeleteProductOptionCommand request = new DeleteProductOptionCommand 
            {
                ProductOptionId = validProductOptionId 
            };

            //Act
            await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            var productOption = _context.ProductOptions.Find(validProductOptionId);
            productOption.ShouldBe(null);
        }
    }
}
