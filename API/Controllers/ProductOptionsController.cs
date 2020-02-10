using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.ProductOptions.Commands.CreateProductOption;
using Application.ProductOptions.Commands.DeleteProductOption;
using Application.ProductOptions.Commands.UpdateProductOption;
using Application.ProductOptions.Queries.GetProductOptions;
using Application.ProductOptions.Queries.GetProductOptionsList;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/products/{id:Guid}/options")]
    public class ProductOptionsController : Controller
    {
        private readonly IProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductOptionsController(IProductDbContext context, IMapper mapper)
        {
            if (context == null || mapper == null)
                throw new ArgumentNullException("Context or Mapper could not get injected.");
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public Task<ProductOptionsListVm> GetAll()
        {
            var request = new GetProductOptionsListQuery();
            var result = new GetProductOptionsListQuery.GetProductOptionsListQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }

        [HttpGet("{optionId}")]
        public Task<ProductOptionVm> Get(Guid optionId)
        {
            var request = new GetProductOptionQuery { ProductOptionId = optionId };
            var result = new GetProductOptionQuery.GetProductOptionQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }

        [HttpPost]
        public async Task Create([FromBody]CreateProductOptionCommand request)
        {
            await new CreateProductOptionCommandHandler(_context).Handle(request, CancellationToken.None);
        }

        [HttpPut("{optionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody]UpdateProductOptionCommand request)
        {
            await new UpdateProductOptionCommandHandler(_context).Handle(request, CancellationToken.None);
            return NoContent();
        }

        [HttpDelete("{optionId}")]
        public async Task<IActionResult> Delete(Guid optionId)
        {
            var request = new DeleteProductOptionCommand { ProductOptionId = optionId };
            await new DeleteProductOptionCommandHandler(_context).Handle(request, CancellationToken.None);
            return NoContent();
        }
    }
}
