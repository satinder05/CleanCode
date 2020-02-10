using Application.ProductOptions.Queries.GetProductOptionsList;
using Application.UnitTests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.ProductOptions.Queries
{
    public class GetProductOptionsListQueryTests : QueryTestBase
    {
        [Fact]
        public async Task Handle_GivenValidProductId_GetsProductOptions()
        {
            //Arrange
            var productId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4905");
            var request = new GetProductOptionsListQuery {ProductId = productId };

            var handler = new GetProductOptionsListQuery.GetProductOptionsListQueryHandler(_context, _mapper);
            int testProductOptionsCount = 2;

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProductOptionsListVm>();
            result.ProductOptions.Count.ShouldBe(testProductOptionsCount);
        }

        [Fact]
        public async Task Handle_GivenProductIdWithoutOptions_ShouldGetEmptyList()
        {
            //Arrange
            var productId = Guid.NewGuid();
            var request = new GetProductOptionsListQuery { ProductId = productId };

            var handler = new GetProductOptionsListQuery.GetProductOptionsListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProductOptionsListVm>();
            result.ProductOptions.Count.ShouldBe(0);
        }
    }
}
