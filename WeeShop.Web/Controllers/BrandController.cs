using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeeShop.Application.ApplicationConstants;
using WeeShop.Application.Common;
using WeeShop.Application.DTO.Brand;
using WeeShop.Application.Services.Interface;

namespace WeeShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _IbrandService;
        protected readonly API_Response _response;

        public BrandController(IBrandService brandService)
        {
            _IbrandService = brandService;
            _response = new API_Response();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<API_Response>> Create (CreateBrandDTO createBrandDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                }
                var entity = await _IbrandService.CreateAsync(createBrandDTO);
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
                var entity = await _IbrandService.GetAllAsync();
                                
                if(entity == null)
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
                if(id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                }
                var brand = await _IbrandService.GetByIdAsync(id);
                if(brand == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = brand;
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
        public async Task<ActionResult<API_Response>> Update(UpdateBrandDTO updateBrandDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                }
                await _IbrandService.UpdateAsync(updateBrandDTO);
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
                var brand = await _IbrandService.GetByIdAsync(id);
                if(brand==null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                }
                await _IbrandService.DeleteAsync(id);
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