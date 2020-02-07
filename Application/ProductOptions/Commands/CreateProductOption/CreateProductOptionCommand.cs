using System;

namespace Application.ProductOptions.Commands.CreateProductOption
{
    public class CreateProductOptionCommand
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
