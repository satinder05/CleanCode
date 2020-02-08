using Application.UnitTests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Application.Products.Commands.DeleteProduct;
using Application.Common.Exceptions;
using System.Linq;

namespace Application.UnitTests.Products.Commands
{
    public class DeleteProductCommandTests : CommandTestBase
    {
        private DeleteProductCommandHandler _commandHandler;

        public DeleteProductCommandTests()
            : base()
        {
            _commandHandler = new DeleteProductCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_WhenTryingToDeleteNotExistingProductId_ThrowsNotFoundException()
        {
            DeleteProductCommand request = new DeleteProductCommand { ProductId = new Guid() };

            await Assert.ThrowsAsync<NotFoundException>(() => _commandHandler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidProductIdWithOptions_ShouldDeleteProductAndItsOptions()
        {
            //Arrange
            var validProductId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4905");

            DeleteProductCommand request = new DeleteProductCommand { ProductId = validProductId };

            //Act
            await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            var product = _context.Products.Find(validProductId);
            var productOptions = _context.ProductOptions.Where(o => o.ProductId == validProductId).ToList();

            product.ShouldBe(null);
            productOptions.Count.ShouldBe(0);
        }
    }
}
