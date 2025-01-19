using AutoMapper;
using MicroservicesApp.Services.CartAPI.Models;
using MicroservicesApp.Services.CartAPI.Models.Dto;


namespace MicroservicesApp.Services.CartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>();
                config.CreateMap<CartHeaderDto, CartHeader>();

                config.CreateMap<CartDetails, CartDetailsDto>();
                config.CreateMap<CartDetailsDto, CartDetails>();
            });
            return mappingConfig;
        }
    }
}