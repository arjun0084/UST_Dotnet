using AutoMapper;
using microservices.Services.CouponAPI.Models;
using microservices.Services.CouponAPI.Models.Dto;

namespace microservices.Services.CouponAPI
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();  
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingconfig;
        }

    }
}
