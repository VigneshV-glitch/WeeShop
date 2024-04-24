using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeeShop.Application.ApplicationConstants;
using WeeShop.Application.Common;
using WeeShop.Application.DTO.Product;
using WeeShop.Application.Pagination;
using WeeShop.Application.Services.Interface;

namespace WeeShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _IproductService;
        protected readonly API_Response _response;

        public ProductController(IProductService productService)
        {
            _IproductService = productService;
            _response = new API_Response();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<API_Response>> Create(CreateProductDTO createProductDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                }
                var entity = await _IproductService.CreateAsync(createProductDTO);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.CreateOperationSuccess;
                _response.Result = entity;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<API_Response>> GetAll()
        {
            try
            {
                var entity = await _IproductService.GetAllAsync();

                if (entity == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = entity;

            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpPost]
        [Route("Pagination")]
        public async Task<ActionResult<API_Response>> Pagination(PaginationModel paginationModel)
        {
            try
            {
                var entity = await _IproductService.GetPagination(paginationModel);

                if (entity == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = entity;

            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpGet]
        [Route("GetbyID")]
        public async Task<ActionResult<API_Response>> GetbyId(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                }
                var product = await _IproductService.GetByIdAsync(id);
                if (product == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = product;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<API_Response>> Update(UpdateProductDTO updateProductDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                }
                await _IproductService.UpdateAsync(updateProductDTO);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.UpdateOperationSuccess;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<API_Response>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                }
                var product = await _IproductService.GetByIdAsync(id);
                if (product == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                }
                await _IproductService.DeleteAsync(id);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.DeleteOperationSuccess;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }
    }
}