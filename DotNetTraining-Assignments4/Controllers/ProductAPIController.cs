using DotNetTraining_Assignments4.Features.ProductFeatures.Commands;
using DotNetTraining_Assignments4.Features.ProductFeatures.Queries;
using DotNetTraining_Assignments4.Models;
using DotNetTraining_Assignments4.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTraining_Assignments4.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public ProductAPIController()
        {            
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<Product> products = await Mediator.Send(new GetAllProductQuery());
                _response.Result = products;
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
                Product product = await Mediator.Send(new GetProductByIdQuery { ProductId = id });
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
        public async Task<ResponseDto> Post([FromBody] CreateProductCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                _response.IsSuccess = result > 0;
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
        public async Task<ResponseDto> Put(UpdateProductCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                _response.IsSuccess = result > 0;
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
                var result = await Mediator.Send(new DeleteProductCommand { ProductId = id });
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
