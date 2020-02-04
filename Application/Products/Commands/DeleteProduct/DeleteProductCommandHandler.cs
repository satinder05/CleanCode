using Application.Common.Interfaces;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler
    {
        private readonly IProductDbContext _context;

        public DeleteProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        //public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.Products
        //            .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(Product), request.Id);
        //    }
        //}
    }
}
