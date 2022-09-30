using DotNetTraining_Assignments3.Models;
using DotNetTraining_Assignments3.Models.Dtos;

namespace DotNetTraining_Assignments3.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        public Task<ProductDto> GetProductById(int productId);
        Task<bool> CreateProduct(ProductCreateDto productDto);
        Task<bool> UpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
