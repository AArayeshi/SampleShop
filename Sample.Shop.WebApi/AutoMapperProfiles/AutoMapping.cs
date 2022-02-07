using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sample.Shop.Business.Models;
using Sample.Shop.WebApi.Contracts;

namespace Sample.Shop.WebApi.AutoMapperProfiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // means you want to map from Product to ProductContract
            CreateMap<Product, ProductContract>()
                .ForMember(productContract => productContract.Price, opt => opt.MapFrom(product => product.Price / 100));
        }
    }
}
