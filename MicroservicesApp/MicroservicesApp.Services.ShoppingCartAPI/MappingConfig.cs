using AutoMapper;
using MicroservicesApp.Services.ShoppingCartAPI.Models;
using MicroservicesApp.Services.ShoppingCartAPI.Models.Dto;


namespace MicroservicesApp.Services.ShoppingCartAPI
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