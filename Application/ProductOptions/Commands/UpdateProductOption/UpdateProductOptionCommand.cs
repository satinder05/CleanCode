using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductOptions.Commands.UpdateProductOption
{
    public class UpdateProductOptionCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
