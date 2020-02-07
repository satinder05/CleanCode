using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductDetailQuery
    {
        public Guid ProductId { get; set; }

        public class GetProductDetailQueryHandler
        {
            private readonly IProductDbContext _context;
            private readonly IMapper _mapper;

            public GetProductDetailQueryHandler(IProductDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.ProductId);

                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), request.ProductId);
                }

                return _mapper.Map<ProductDetailVm>(product);
            }
        }
    }
}
