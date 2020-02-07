using Application.Products.Queries;
using Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using System;
using Application.Common.Exceptions;

namespace Application.UnitTests.Products.Queries
{
    public class GetProductDetailQueryTests : QueryTestBase
    {
        private readonly GetProductDetailQuery.GetProductDetailQueryHandler _queryHandler;
        public GetProductDetailQueryTests()
            : base()
        {
            _queryHandler = new GetProductDetailQuery.GetProductDetailQueryHandler(_context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidProductId_GetsProductDetail()
        {
            //Arrange
            Guid productId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4811");
            var request = new GetProductDetailQuery { ProductId = productId };

            //Act
            var result = await _queryHandler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProductDetailVm>();
            result.Id.ShouldBe(productId);
        }

        [Fact]
        public async Task Handle_WhenTryingToGetDetailsOfNotExistingProductId_ThrowsNotFoundException()
        {
            var request = new GetProductDetailQuery
            {
                ProductId = new Guid()
            };

            await Assert.ThrowsAsync<NotFoundException>(() => _queryHandler.Handle(request, CancellationToken.None));
        }
    }
}
