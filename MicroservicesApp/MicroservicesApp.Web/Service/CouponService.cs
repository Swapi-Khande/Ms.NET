using MicroservicesApp.Web.Models;
using MicroservicesApp.Web.Service.IService;
using MicroservicesApp.Web.Utility;

namespace MicroservicesApp.Web.Service
{
    public class ProductService: IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.POST,
                Data = productDto,
                Url = SConstants.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.DELETE,
                Url = SConstants.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.GET,
                Url = SConstants.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> GetProductAsync(string productCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.GET,
                Url = SConstants.ProductAPIBase + "/api/product/GetByCode/" + productCode
            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.GET,
                Url = SConstants.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto?> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SConstants.ApiType.PUT,
                Data = productDto,
                Url = SConstants.ProductAPIBase + "/api/product"
            });
        }
    }
}
