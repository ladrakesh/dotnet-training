using DotNetTraining_Assignments2.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace DotNetTraining_Assignments2.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProductById(int productId);
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
