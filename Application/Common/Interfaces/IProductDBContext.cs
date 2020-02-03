using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProductDBContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductOption> ProductOptions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
