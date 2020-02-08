using API.IntegrationTests.Common;
using Application.Products.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTests.Controllers.Products
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateProductCommand_ReturnsSuccessStatusCode()
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
