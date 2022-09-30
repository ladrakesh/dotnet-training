using AutoMapper;
using DotNetTraining_Assignments3.Models;
using DotNetTraining_Assignments3.Models.Dtos;
using DotNetTraining_Assignments3.Repositories;

namespace DotNetTraining_Assignments3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public Task<bool> CreateProduct(ProductCreateDto productDto)
        {
            var categoryId = categoryRepository.GetCategoryIdByName(productDto.Category);
            var product = new Product()
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = categoryId,
            };

            return productRepository.CreateProduct(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await productRepository.DeleteProduct(productId);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            return await productRepository.GetProductById(productId);            
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await productRepository.GetProducts();           
        }

        public async Task<bool> UpdateProduct(ProductDto productDto)
        {
            Product product = mapper.Map<ProductDto, Product>(productDto);
            return await productRepository.UpdateProduct(product);
        }
    }
}
