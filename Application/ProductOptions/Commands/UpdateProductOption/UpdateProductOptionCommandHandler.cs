using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductOptions.Commands.UpdateProductOption
{
    public class UpdateProductOptionCommandHandler
    {
        private readonly IProductDbContext _context;
        public UpdateProductOptionCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<ProductOption> Handle(UpdateProductOptionCommand request, CancellationToken cancellationToken)
        {
            var productOption = await _context.ProductOptions.FindAsync(request.Id);

            if (productOption == null)
            {
                throw new NotFoundException(nameof(ProductOption), request.Id);
            }

            productOption.Name = request.Name;
            productOption.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);
            return productOption;
        }
    }
}
