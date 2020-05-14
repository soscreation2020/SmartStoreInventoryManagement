using Microsoft.AspNetCore.Mvc;
using SmartStoreInventoryManagement.Core.AspNetCore;
using SmartStoreInventoryManagement.Core.Enums;
using SmartStoreInventoryManagement.Core.Services_Models;
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
    public class ProductShelftsController: BaseApiController
    {
        private readonly IProductShelfService _productShelftService;
        public ProductShelftsController(ProductShelfService productShelfService)
        {
            _productShelftService = productShelfService;

        }


        [HttpPost]
        // [Route("SetupCategory")]
        public async Task<IActionResult> Setup([FromBody]ProductShelfViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty Sabmit", ApiResponseCodes.INVALID_REQUEST);

            var result = await _productShelftService.Setup(viewModel, this.CurrentUser.UserId);

            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }

            return this.ApiResponse<ProductShelfViewModel>(viewModel, "check Item was setup successfully.", ApiResponseCodes.OK);
        }



        [HttpPost]
        //[Route("GetAllCategory")]

        public async Task<IActionResult> GetAll([FromBody]SearchProductShelfViewModel viewModel)
        {
            if (viewModel.PageIndex == -1 || viewModel.PageSize == -1)
                return this.ApiResponse<string>(null, $"{viewModel.PageIndex} or {viewModel.PageSize} can not be -1", ApiResponseCodes.INVALID_REQUEST);

            var result = await _productShelftService.GetAll(viewModel);

            if ((result.Code != ApiResponseCodes.OK))
            {
                return base.ApiResponse<string>(null, result.Description,
                    ApiResponseCodes.EXCEPTION, 1);
            }
            if (result.Payload == null)
            {
                return this.ApiResponse<List<ProductShelfListViewModel>>(result.Payload, "Record not Found.", ApiResponseCodes.NOT_FOUND);

            }
            return this.ApiResponse<List<ProductShelfListViewModel>>(result.Payload, "successful.", ApiResponseCodes.OK);

        }



        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {

            var result = await _productShelftService.GetById(id: id);

            if ((result.Code != ApiResponseCodes.OK))
            {
                return base.ApiResponse<string>(null, result.Description,
                    ApiResponseCodes.INVALID_REQUEST, 1);
            }

            if (result.Payload == null)
            {
                return this.ApiResponse<ProductShelfListViewModel>(result.Payload, "No record found.", ApiResponseCodes.NOT_FOUND);

            }
            return this.ApiResponse<ProductShelfListViewModel>(result.Payload, "successful.", ApiResponseCodes.OK);

        }



        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]ProductShelfEditViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);

            var result = await _productShelftService.Edit(viewModel, this.CurrentUser.UserId);


            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }
            return this.ApiResponse<ProductShelfEditViewModel>(viewModel, "successful.", ApiResponseCodes.OK);

        }



        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]ProductShelfEditViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);

            var result = await _productShelftService.Delete(Guid.Parse(viewModel.Id), this.CurrentUser.UserId);


            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }
            return this.ApiResponse<ProductShelfEditViewModel>(viewModel, "successful.", ApiResponseCodes.OK);

        }
    }
    
}
