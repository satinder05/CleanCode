using Application.Products.Queries;
using Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Products.Queries
{
    public class GetProductDetailByNameQueryTests : QueryTestBase
    {
        private readonly GetProductDetailByNameQuery.GetProductDetailByNameQueryHandler _queryHandler;

        public GetProductDetailByNameQueryTests()
            : base()
        {
            _queryHandler = new GetProductDetailByNameQuery.GetProductDetailByNameQueryHandler(_context, _mapper);
        }
        
        [Fact]
        public async Task Handle_GivenExistingProductName_GetsProductDetail()
        {
            //Arrange
            string productName = "Samsung Galaxy S10";
            var request = new GetProductDetailByNameQuery
            {
                ProductName = productName
            };

            //Act
            var result = await _queryHandler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<ProductDetailVm>();
            result.Name.ShouldBe(productName);
        }

        [Fact]
        public async Task Handle_GivenNonExistingProductName_GetsNullResult()
        {
            //Arrange
            string productName = "Random Name";
            var request = new GetProductDetailByNameQuery
            {
                ProductName = productName
            };

            //Act
            var result = await _queryHandler.Handle(request, CancellationToken.None);

            //Assert
            result.ShouldBeNull();
        }
    }
}
