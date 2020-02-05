using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailByNameQuery
    {
        public string ProductName { get; set; }

        public class GetProductDetailByNameQueryHandler
        {
            private readonly IProductDbContext _context;
            private readonly IMapper _mapper;

            public GetProductDetailByNameQueryHandler(IProductDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDetailVm> Handle(GetProductDetailByNameQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(c => c.Name == request.ProductName)
                                            .ProjectTo<ProductDetailVm>(_mapper.ConfigurationProvider)
                                            .SingleOrDefaultAsync(cancellationToken);

                return product;
            }
        }
    }
}
