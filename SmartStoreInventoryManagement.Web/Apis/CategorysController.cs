using Microsoft.AspNetCore.Mvc;
using SmartStoreInventoryManagement.Core.AspNetCore;
using SmartStoreInventoryManagement.Core.Enums;
using SmartStoreInventoryManagement.Core.Services_Models.Interface;
using SmartStoreInventoryManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Web.Apis
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategorysController : BaseApiController
    {
        private readonly ICategoryService _categoryService;
        public CategorysController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        [HttpPost]
       // [Route("SetupCategory")]
        public async Task<IActionResult> SetupCategory([FromBody]CategoryViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty Sabmit", ApiResponseCodes.INVALID_REQUEST);

            var result = await _categoryService.SetupCategory(viewModel, this.CurrentUser.UserId);

            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }

            return this.ApiResponse<CategoryViewModel>(viewModel, "check Item was setup successfully.", ApiResponseCodes.OK);
        }


        [HttpPost]
        //[Route("GetAllCategory")]

        public async Task<IActionResult> GetAllCategory([FromBody]SearchCategoryViewModel viewModel)
        {
            if (viewModel.PageIndex == -1 || viewModel.PageSize == -1)
                return this.ApiResponse<string>(null, $"{viewModel.PageIndex} or {viewModel.PageSize} can not be -1", ApiResponseCodes.INVALID_REQUEST);

            var result = await _categoryService.GetAllCategory(viewModel);

            if ((result.Code != ApiResponseCodes.OK))
            {
                return base.ApiResponse<string>(null, result.Description,
                    ApiResponseCodes.EXCEPTION, 1);
            }
            if (result.Payload == null)
            {
                return this.ApiResponse<List<CategoryListViewModel>>(result.Payload, "Record not Found.", ApiResponseCodes.NOT_FOUND);

            }
            return this.ApiResponse<List<CategoryListViewModel>>(result.Payload, "successful.", ApiResponseCodes.OK);

        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {

            var result = await _categoryService.GetCategoryById(id: id);

            if ((result.Code != ApiResponseCodes.OK))
            {
                return base.ApiResponse<string>(null, result.Description,
                    ApiResponseCodes.INVALID_REQUEST, 1);
            }

            if (result.Payload == null)
            {
                return this.ApiResponse<CategoryListViewModel>(result.Payload, "No record found.", ApiResponseCodes.NOT_FOUND);

            }
            return this.ApiResponse<CategoryListViewModel>(result.Payload, "successful.", ApiResponseCodes.OK);

        }



        [HttpPost]
        public async Task<IActionResult> EditCategory([FromBody]CategoryEditViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);

            var result = await _categoryService.EditCategory(viewModel, this.CurrentUser.UserId);


            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }
            return this.ApiResponse<CategoryEditViewModel>(viewModel, "successful.", ApiResponseCodes.OK);

        }



        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]CategoryEditViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);

            var result = await _categoryService.DeleteCategory(Guid.Parse(viewModel.Id), this.CurrentUser.UserId);


            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }
            return this.ApiResponse<CategoryEditViewModel>(viewModel, "successful.", ApiResponseCodes.OK);

        }
    }
}
