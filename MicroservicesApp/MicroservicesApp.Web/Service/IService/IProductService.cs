using MicroservicesApp.Web.Models;

namespace MicroservicesApp.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetProductAsync(string prodName);
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductsAsync(ProductDto prodDto);
        Task<ResponseDto?> UpdateProductsAsync(ProductDto prodDto);
        Task<ResponseDto?> DeleteProductsAsync(int id);
    }
}
