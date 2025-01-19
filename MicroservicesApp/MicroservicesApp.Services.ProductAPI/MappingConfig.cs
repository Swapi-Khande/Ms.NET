using AutoMapper;
using MicroservicesApp.Services.ProductAPI.Models;
using MicroservicesApp.Services.ProductAPI.Models.Dto;

namespace MicroservicesApp.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}