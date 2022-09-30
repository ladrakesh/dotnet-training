using DotNetTraining_Assignments3.Models;
using DotNetTraining_Assignments3.Models.Dtos;
using Microsoft.AspNetCore.Routing.Constraints;

namespace DotNetTraining_Assignments3.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        public Task<ProductDto> GetProductById(int productId);
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
