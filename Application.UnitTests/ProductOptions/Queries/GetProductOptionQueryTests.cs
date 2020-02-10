using Application.UnitTests.Common;
using System;
using Application.ProductOptions.Queries.GetProductOptions;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Application.Common.Exceptions;

namespace Application.UnitTests.ProductOptions.Queries
{
    public class GetProductOptionQueryTests : QueryTestBase
    {
        private readonly GetProductOptionQuery.GetProductOptionQueryHandler _queryHandler;

        public GetProductOptionQueryTests()
            : base()
        {
            _queryHandler = new GetProductOptionQuery.GetProductOptionQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidProductOptionId_And_ProductId_GetsProductOption()
        {
            //Arrange
            Guid productOptionId = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4904");
            Guid productId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4905");

            var request = new GetProductOptionQuery
            {
                ProductId = productId,
                ProductOptionId = productOptionId
            };

            //Act
            var result = await _queryHandler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProductOptionVm>();
            result.Id.ShouldBe(productOptionId);
        }

        [Fact]
        public async Task Handle_WhenTryingToGetDetailsOfNonExistingProductOptionId_ThrowsNotFoundException()
        {
            //Arrange
            Guid productOptionId = Guid.NewGuid();
            Guid productId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4905");

            var request = new GetProductOptionQuery
            {
                ProductId = productId,
                ProductOptionId = productOptionId
            };

            await Assert.ThrowsAsync<NotFoundException>(() => _queryHandler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_WhenProductOptionId_DoesNot_BelongTo_GivenProductId_ThrowsNotFoundException()
        {
            //Arrange
            Guid productOptionId = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4904");
            Guid productId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499");

            var request = new GetProductOptionQuery
            {
                ProductId = productId,
                ProductOptionId = productOptionId
            };

            await Assert.ThrowsAsync<NotFoundException>(() => _queryHandler.Handle(request, CancellationToken.None));
        }
    }
}
