using Application.Common.Interfaces;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using System.Linq;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler
    {
        private readonly IProductDbContext _context;

        public DeleteProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                    .SingleOrDefaultAsync(c => c.Id == request.ProductId, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var productOptions = await _context.ProductOptions.Where(o => o.ProductId == request.ProductId).ToListAsync(cancellationToken);
            _context.ProductOptions.RemoveRange(productOptions);

            _context.Products.Remove(product);
            
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
