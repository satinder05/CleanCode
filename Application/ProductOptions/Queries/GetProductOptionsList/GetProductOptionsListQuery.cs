﻿using Application.Common.Interfaces;
using Application.ProductOptions.Queries.GetProductOptions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductOptions.Queries.GetProductOptionsList
{
    public class GetProductOptionsListQuery
    {
        public Guid ProductId { get; set; }

        public class GetProductOptionsListQueryHandler
        {
            private readonly IProductDbContext _context;
            private readonly IMapper _mapper;

            public GetProductOptionsListQueryHandler(IProductDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductOptionsListVm> Handle(GetProductOptionsListQuery request, CancellationToken cancellationToken)
            {
                var productOptions = await _context.ProductOptions.Where(c => c.ProductId == request.ProductId)
                    .ProjectTo<ProductOptionVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var productOptionsListVm = new ProductOptionsListVm
                {
                    ProductOptions = productOptions
                };

                return productOptionsListVm;
            }
        }
    }
}

