﻿using System;

namespace Domain.Entities
{
    public class ProductOption
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
