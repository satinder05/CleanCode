using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using API.RoutingConstraint;
using Application.Common.Interfaces;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetProductDetail;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public Task<ProductDetailVm> Get(Guid id)
        {
            var request = new GetProductDetailQuery { ProductId = id };
            var result = new GetProductDetailQuery.GetProductDetailQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }

        [HttpGet]
        [QueryStringConstraint("name", true)]
        public Task<ProductDetailVm> GetByName([FromQuery] string name)
        {
            var request = new GetProductDetailByNameQuery { ProductName = name };
            var result = new GetProductDetailByNameQuery.GetProductDetailByNameQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }

        [HttpGet]
        public Task<ProductListVm> GetAll()
        {
            var request = new GetProductsListQuery();
            var result = new GetProductsListQuery.GetProductsListQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }
        

        [HttpPost]
        public async Task Post([FromBody]CreateProductCommand request)
        {
            await new CreateProductCommandHandler(_context).Handle(request, CancellationToken.None);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody]UpdateProductCommand request)
        {
            await new UpdateProductCommandHandler(_context).Handle(request, CancellationToken.None);
            return NoContent();
        }

        // DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    return NoContent();
        //}
    }
}
