using Application.Common.Interfaces;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
    {
        private readonly IProductDbContext _context;

        public UpdateProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.DeliveryPrice = request.DeliveryPrice;

            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
