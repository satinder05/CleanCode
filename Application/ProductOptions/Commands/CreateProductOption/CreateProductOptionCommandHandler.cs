using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductOptions.Commands.CreateProductOption
{
    public class CreateProductOptionCommandHandler
    {
        private readonly IProductDbContext _context;

        public CreateProductOptionCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductOptionCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var productOption = new ProductOption
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                Name = request.Name,
                Description = request.Description
            };
            _context.ProductOptions.Add(productOption);
            await _context.SaveChangesAsync(cancellationToken);
            return productOption.Id;
        }
    }
}
