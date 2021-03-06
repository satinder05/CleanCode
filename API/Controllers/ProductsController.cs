﻿using System;
using System.Threading;
using System.Threading.Tasks;
using API.Common.RoutingConstraint;
using Application.Common.Interfaces;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries;
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
            if (context == null || mapper == null)
                throw new ArgumentNullException("Context or Mapper could not get injected.");
            _context = context;
            _mapper = mapper;            
        }

        [HttpGet("{id}")]
        public Task<ProductDetailVm> GetAsync(Guid id)
        {
            var request = new GetProductDetailQuery { ProductId = id };
            var result = new GetProductDetailQuery.GetProductDetailQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }

        [HttpGet]
        [QueryStringConstraint("name", true)]
        public Task<ProductDetailVm> GetByNameAsync([FromQuery] string name)
        {
            var request = new GetProductDetailByNameQuery { ProductName = name };
            var result = new GetProductDetailByNameQuery.GetProductDetailByNameQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }

        [HttpGet]
        public Task<ProductListVm> GetAllAsync()
        {
            var request = new GetProductsListQuery();
            var result = new GetProductsListQuery.GetProductsListQueryHandler(_context, _mapper).Handle(request, CancellationToken.None);
            return result;
        }
        

        [HttpPost]
        public async Task CreateAsync([FromBody]CreateProductCommand request)
        {
            await new CreateProductCommandHandler(_context).Handle(request, CancellationToken.None);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateProductCommand request)
        {
            await new UpdateProductCommandHandler(_context).Handle(request, CancellationToken.None);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var request = new DeleteProductCommand { ProductId = id };
            await new DeleteProductCommandHandler(_context).Handle(request, CancellationToken.None);
            return NoContent();
        }
    }
}
