using AutoMapper;
using Fleur.Services.CouponAPI.Models;
using Fleur.Services.CouponAPI.Models.Dto;

namespace Fleur.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
                //config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                //config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
                //config.CreateMap<Cart, CartDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
