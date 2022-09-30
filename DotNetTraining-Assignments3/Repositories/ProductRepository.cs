using DotNetTraining_Assignments3.DbContexts;
using DotNetTraining_Assignments3.Models;
using DotNetTraining_Assignments3.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DotNetTraining_Assignments3.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateProduct(Product product)
        {            
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int productId)
        {

            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                return false;
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
          
            ProductDto product = await (from p in _db.Products
                          join c in _db.Categories on p.CategoryId equals c.Id
                          where p.ProductId == productId
                          select new ProductDto
                          {
                              ProductId=p.ProductId,
                              Name = p.Name,
                              Price = p.Price,
                              Description = p.Description,
                              CategoryId = p.CategoryId,
                              Category = c.Name
                          }).FirstOrDefaultAsync();
             
            
            return product == null ? new ProductDto() : product;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productList = from p in _db.Products
                       join c in _db.Categories on p.CategoryId equals c.Id
                       select new ProductDto
                       {
                           ProductId = p.ProductId,
                           Name =p.Name,
                           Price=p.Price,
                           Description=p.Description,                          
                           CategoryId=p.CategoryId,
                           Category=c.Name
                       };

            return productList;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return true;
        }

       
    }
}
