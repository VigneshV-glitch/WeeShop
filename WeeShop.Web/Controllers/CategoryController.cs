using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using WeeShop.Application.ApplicationConstants;
using WeeShop.Application.Common;
using WeeShop.Application.DTO.Category;
using WeeShop.Application.Services.Interface;
using WeeShop.Domain.Contracts;
using WeeShop.Domain.Models;
using WeeShop.Infrastructure.DbContexts;
using WeeShop.Infrastructure.Repositories;

namespace WeeShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _IcategoryService;
        protected API_Response _response;

        public CategoryController(ICategoryService categoryService)
        {
            /*This constructor is used for assign the parameter
           (categoryrepository)value to ==> _IcategoryService*/

           _IcategoryService = categoryService;
            _response = new API_Response();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<API_Response>> Create([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            /*This if condition is validation for ModelState, the
            condition returns false, ! is changed the result
            false into true then execute the BadRequest.*/
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                }
                var entity = await _IcategoryService.CreateAsync(createCategoryDTO);
                _response.StatusCode = HttpStatusCode.Created;
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
            /*(Category)this is from Dbcontext which is defined
            as table name(category) this is from parameter of
            Category Model*/
            return Ok(_response);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<API_Response>> GetAll()
        {
            try
            {
                var Category_Table = await _IcategoryService.GetAllAsync();

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = Category_Table;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
        [HttpGet]
        [Route("GetbyID")]
        public async Task<ActionResult<API_Response>> GetbyID(int id)
        {
            /*x is assigned as Category Model then
             Find the Id value of Category model
             which is Equals to input id*/
            try
            {
                var Category_Table = await _IcategoryService.GetbyIdAsync(id);
                if (Category_Table == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.SystemError;
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = Category_Table;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<API_Response>> Update ([FromBody]UpdateCategoryDTO updateCategoryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                }
                var category = _IcategoryService.GetbyIdAsync(updateCategoryDTO.Id);
                if (category == null) 
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                }
                await _IcategoryService.UpdateAsync(updateCategoryDTO);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.UpdateOperationSuccess;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<API_Response>> Delete (int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                }
                var category = await _IcategoryService.GetbyIdAsync(id);
                if (category == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                }
                await _IcategoryService.DeleteAsync(id);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.DeleteOperationSuccess;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
    }
}