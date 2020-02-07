using Domain.Entities;
using System;
using AutoMapper;
using Application.Common.Mappings;

namespace Application.Products.Queries
{
    public class ProductDetailVm : IMapFrom<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailVm>();
        }
    }
}
