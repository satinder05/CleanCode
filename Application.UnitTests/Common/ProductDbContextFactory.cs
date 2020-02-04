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

            //Can create Test data here

            return context;
        }

        public static void Destroy(ProductDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
