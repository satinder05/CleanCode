using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductOptions.Queries.GetProductOptions
{
    public class GetProductOptionQuery
    {
        public Guid ProductId { get; set; }
        public Guid ProductOptionId { get; set; }

        public class GetProductOptionQueryHandler
        {
            private readonly IProductDbContext _context;
            private readonly IMapper _mapper;

            public GetProductOptionQueryHandler(IProductDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductOptionVm> Handle(GetProductOptionQuery request, CancellationToken cancellationToken)
            {
                var productOption = await _context.ProductOptions.FindAsync(request.ProductOptionId);

                if (productOption == null)
                    throw new NotFoundException(nameof(ProductOption), request.ProductOptionId);
                if (productOption.ProductId != request.ProductId)
                    throw new NotFoundException(nameof(ProductOption), request.ProductId);

                return _mapper.Map<ProductOptionVm>(productOption);
            }
        }
    }
}
