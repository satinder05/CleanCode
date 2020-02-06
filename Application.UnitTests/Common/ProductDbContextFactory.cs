using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace Application.UnitTests.Common
{
    public class ProductDbContextFactory
    {
        public static ProductDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ProductDbContext(options);
            context.Database.EnsureCreated();

            //Add Test data
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

            return context;
        }

        public static void Destroy(ProductDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
