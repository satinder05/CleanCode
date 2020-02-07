using Application.ProductOptions.Queries.GetProductOptionsList;
using Application.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.ProductOptions.Queries
{
    public class GetProductOptionsListQueryTests : QueryTestBase
    {
        [Fact]
        public async Task GetProductOptionsList()
        {
            //Arrange
            var request = new GetProductOptionsListQuery();
            var handler = new GetProductOptionsListQuery.GetProductOptionsListQueryHandler(_context, _mapper);
            int minimumTestProductOptionsCount = 3;

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProductOptionsListVm>();
            result.ProductOptions.Count.ShouldBeGreaterThan(minimumTestProductOptionsCount);
        }
    }
}
