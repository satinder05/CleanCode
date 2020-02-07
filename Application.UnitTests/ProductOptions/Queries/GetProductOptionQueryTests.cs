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
        public async Task Handle_GivenValidProductOptionId_GetsProductOption()
        {
            //Arrange
            Guid productOptionId = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4904");
            var request = new GetProductOptionQuery
            {
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
            var request = new GetProductOptionQuery
            {
                ProductOptionId = new Guid()
            };

            await Assert.ThrowsAsync<NotFoundException>(() => _queryHandler.Handle(request, CancellationToken.None));
        }
    }
}
