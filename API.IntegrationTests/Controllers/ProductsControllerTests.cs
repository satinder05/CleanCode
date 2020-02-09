using API.IntegrationTests.Common;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

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
        public async Task GetApisRouteTest(string url)
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

        [Fact]
        public async Task Update_GivenUpdateProductCommand_ReturnsSuccessStatusCode()
        {
            UpdateProductCommand command = new UpdateProductCommand
            {
                Id = new Guid("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3"),
                Name = "Apple iPhone 6S",
                Description = "New mobile product from Apple.",
                Price = 1199.99m,
                DeliveryPrice = 19.99m
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync("/api/products/DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAll_ReturnsProductListViewModel()
        {
            var response = await _client.GetAsync("/api/products");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<ProductListVm>(response);

            vm.ShouldBeOfType<ProductListVm>();
            vm.Products.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Get_GivenValidProductId_ReturnsProductDetail()
        {
            var response = await _client.GetAsync("/api/products/DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<ProductDetailVm>(response);

            result.ShouldBeOfType<ProductDetailVm>();
            result.Id.ShouldBe(new Guid("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3"));
        }

        [Fact]
        public async Task GetByName_GivenValidProductName_ReturnsProductDetail()
        {
            var response = await _client.GetAsync("/api/products?name=Apple iPhone 6S");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<ProductDetailVm>(response);

            result.ShouldBeOfType<ProductDetailVm>();
            result.Name.ShouldBe("Apple iPhone 6S");
        }


    }
}
