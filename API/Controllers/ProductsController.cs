using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductDbContext _context;

        public ProductsController(IProductDbContext context)
        {
            _context = context;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task Post([FromBody]CreateProductCommand request)
        {
            await new CreateProductCommandHandler(_context).Handle(request, CancellationToken.None);
        }

        // PUT api/<controller>/5
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
