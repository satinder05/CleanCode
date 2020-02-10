using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.IO;
using System;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace API.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");

            builder.ConfigureServices(services =>
            {
                var connection = new SqliteConnection("DataSource=products.db");
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .BuildServiceProvider();

                var options = new DbContextOptionsBuilder<ProductDbContext>()
                    .UseSqlite(connection)
                    .Options;

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<ProductDbContext>(options =>
                {
                    options.UseSqlite(connection);
                    options.UseInternalServiceProvider(serviceProvider);
                });
               
                services.AddScoped<IProductDbContext, ProductDbContext>();

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<ProductDbContext>();
                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                // Ensure the database is created.
                context.Database.EnsureCreated();

            });


        }

    }
}
