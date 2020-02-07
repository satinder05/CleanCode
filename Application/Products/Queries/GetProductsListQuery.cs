using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductsListQuery
    {
        public class GetProductsListQueryHandler
        {
            private readonly IProductDbContext _context;
            private readonly IMapper _mapper;

            public GetProductsListQueryHandler(IProductDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductListVm> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products
                    .ProjectTo<ProductDetailVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var productListVm = new ProductListVm
                {
                    Products = products
                };

                return productListVm;
            }
        }
    }
}
