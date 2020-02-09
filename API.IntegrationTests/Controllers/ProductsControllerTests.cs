using API.IntegrationTests.Common;
using Application.Products.Commands.CreateProduct;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTests.Controllers
{
    public class ProductsControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductsControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/api/products")]
        [InlineData("/api/products/8F2E9176-35EE-4F0A-AE55-83023D2DB1A3")]
        [InlineData("/api/products?name=Samsung Galaxy S7")]
        public async Task ApiRouteTest(string url)
        {

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Create_GivenCreateProductCommand_ReturnsSuccessStatusCode()
        {
            CreateProductCommand command = new CreateProductCommand
            {
                Name = "Test Product",
                Description = "First Test Product",
                Price = 200.55m,
                DeliveryPrice = 20
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync("/api/products", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
