using DotNetTraining_Assignments2.Models;
using System.Data;
using System.Data.SqlClient;

namespace DotNetTraining_Assignments2.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly IConfiguration _config;
        private readonly SqlUtil _sqlUtil;

        public ProductRepository(IConfiguration config , SqlUtil sqlUtil)
        {
            _config = config;
            _sqlUtil = sqlUtil;
        }

        private string GetConnectionString()
        {
            return _config.GetValue<string>("ConnectionStrings:localserver");
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            IList<Product> products = new List<Product>();
            await using SqlConnection con = _sqlUtil.GetSqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("spGetAllProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
               // con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    Product product = new Product();
                    product.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    product.Name = rdr["Name"].ToString();
                    product.Description = rdr["Description"].ToString();
                    product.Price = Convert.ToDouble(rdr["Price"]);
                    product.CategoryName = rdr["CategoryName"].ToString();

                    products.Add(product);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return products;
        }

        public async Task<Product> GetProductById(int productId)
        {
            Product product = new Product();
            await using SqlConnection con = _sqlUtil.GetSqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("spGetProductById", con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    product.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    product.Name = rdr["Name"].ToString();
                    product.Description = rdr["Description"].ToString();
                    product.Price = Convert.ToDouble(rdr["Price"]);
                    product.CategoryName = rdr["CategoryName"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return product;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            bool isSuccess;
            await using SqlConnection con = _sqlUtil.GetSqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("spAddProduct", con);
                
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);
                
                con.Open();
                cmd.ExecuteNonQuery();
                isSuccess = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return isSuccess;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            bool isSuccess;
            await using SqlConnection con = _sqlUtil.GetSqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateProduct", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);

                con.Open();
                cmd.ExecuteNonQuery();
                isSuccess = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return isSuccess;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            bool isSuccess;
            await using SqlConnection con = _sqlUtil.GetSqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteProduct", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", productId);
                con.Open();
                cmd.ExecuteNonQuery();
                isSuccess = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return isSuccess;
        }
    }
}
