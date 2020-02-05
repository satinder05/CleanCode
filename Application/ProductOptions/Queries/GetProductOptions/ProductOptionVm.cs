using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.ProductOptions.Queries.GetProductOptions
{
    public class ProductOptionVm : IMapFrom<ProductOption>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductOption, ProductOptionVm>();
        }
    }
}
