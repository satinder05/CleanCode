using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductOptions.Commands.DeleteProductOption
{
    public class DeleteProductOptionCommandHandler
    { 
        private readonly IProductDbContext _context;
        public DeleteProductOptionCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteProductOptionCommand request, CancellationToken cancellationToken)
        {
            var productOption = await _context.ProductOptions.FindAsync(request.ProductOptionId);

            if (productOption == null)
            {
                throw new NotFoundException(nameof(ProductOption), request.ProductOptionId);
            }

            _context.ProductOptions.Remove(productOption);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
