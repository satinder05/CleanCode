using Newtonsoft.Json;
using Persistence;
using System;
using Domain.Entities;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Common
{
    public class Utilities
    {
        public static void PopulateTestData(ProductDbContext context)
        {
            //Products
            context.Products.AddRange(new[] {
                new Product { Id = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4905"), Name = "Samsung Galaxy S10", Description = "Newest mobile from Samsung.", Price = 900.99M, DeliveryPrice = 20.99M},
                new Product { Id = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"), Name = "Samsung Galaxy S9", Description = "Older mobile from Samsung.", Price = 700.99M, DeliveryPrice = 20.99M},
                new Product { Id = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4811"), Name = "Nokia New Model", Description = "Good Old Nokia.", Price = 200.99M, DeliveryPrice = 10.99M},
            });

            //ProductOptions
            context.ProductOptions.AddRange(new[] {
                new ProductOption { Id = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4905"), ProductId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4905"), Name = "White", Description = "White Samsung S10"},
                new ProductOption { Id = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4904"), ProductId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4905"), Name = "Gold", Description = "Gold Samsung S10"},
                new ProductOption { Id = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4499"), ProductId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4499"), Name = "White", Description = "White Samsung S9"},
                new ProductOption { Id = new Guid("5BDEAB22-6BBC-43AE-9E07-2561660F4811"), ProductId = new Guid("8BDEAB77-6BBC-43AE-9E07-2561660F4811"), Name = "Black", Description = "Black Nokia."},
            });

            context.SaveChanges();
        }

        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }
    }
}
