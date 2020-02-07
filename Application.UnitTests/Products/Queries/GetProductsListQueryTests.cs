using Application.Products.Queries;
using Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;


namespace Application.UnitTests.Products.Queries
{
    public class GetProductsListQueryTests : QueryTestBase
    {
        [Fact]
        public async Task GetProductsList()
        {
            //Arrange
            var request = new GetProductsListQuery();
            var handler = new GetProductsListQuery.GetProductsListQueryHandler(_context, _mapper);
            int minimumTestProductCount = 2;

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProductListVm>();
            result.Products.Count.ShouldBeGreaterThan(minimumTestProductCount);
        }
    }
}
