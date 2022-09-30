using DotNetTraining_Assignments3.Models;
using DotNetTraining_Assignments3.Models.Dtos;
using DotNetTraining_Assignments3.Repositories;
using DotNetTraining_Assignments3.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTraining_Assignments3.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductService _productService;

        public ProductAPIController(IProductService productService)
        {
            _productService = productService;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productService.GetProducts();
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
                ProductDto product = await _productService.GetProductById(id);
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
        public async Task<ResponseDto> Post([FromBody] ProductCreateDto product)
        {
            try
            {
                bool result = await _productService.CreateProduct(product);
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
        public async Task<ResponseDto> Put([FromBody] ProductDto product)
        {
            try
            {
                bool result = await _productService.UpdateProduct(product);
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
                bool result = await _productService.DeleteProduct(id);
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
