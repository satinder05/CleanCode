using API.IntegrationTests.Common;
using Application.ProductOptions.Commands.CreateProductOption;
using Application.ProductOptions.Commands.UpdateProductOption;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTests.Controllers
{
    public class ProductOptionsControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductOptionsControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/api/products/DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3/options")]
        [InlineData("/api/products/DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3/options/5C2996AB-54AD-4999-92D2-89245682D534")]
        public async Task GetApisRouteTest(string url)
        {
            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Create_GivenCreateProductOptionCommand_ReturnsSuccessStatusCode()
        {
            CreateProductOptionCommand command = new CreateProductOptionCommand
            {
                ProductId = new Guid("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "Option",
                Description = "New Option",
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync("/api/products/8F2E9176-35EE-4F0A-AE55-83023D2DB1A3/options", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Update_GivenCreateProductCommand_ReturnsSuccessStatusCode()
        {
            UpdateProductOptionCommand command = new UpdateProductOptionCommand
            {
                Id = new Guid("0643CCF0-AB00-4862-B3C5-40E2731ABCC9"),
                Name = "White",
                Description = "Samsung Galaxy S7",
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync("/api/products/8F2E9176-35EE-4F0A-AE55-83023D2DB1A3/options/0643CCF0-AB00-4862-B3C5-40E2731ABCC9", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
