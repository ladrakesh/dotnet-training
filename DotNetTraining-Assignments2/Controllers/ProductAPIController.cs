using DotNetTraining_Assignments2.Models;
using DotNetTraining_Assignments2.Models.Dtos;
using DotNetTraining_Assignments2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTraining_Assignments2.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<Product> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                Product product = await _productRepository.GetProductById(id);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] Product product)
        {
            try
            {
                bool result = await _productRepository.CreateProduct(product);
                _response.IsSuccess = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] Product product)
        {
            try
            {
                bool result = await _productRepository.UpdateProduct(product);
                _response.IsSuccess = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                bool result = await _productRepository.DeleteProduct(id);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }
    }
}
