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
    public class UnitOfMeasuresController : BaseApiController
    {
        private readonly IUnitOfMeasureService _unitOfMeasureService;
        public UnitOfMeasuresController(IUnitOfMeasureService unitOfMeasureService)
        {
            _unitOfMeasureService = unitOfMeasureService;

        }


        [HttpPost]
        // [Route("SetupCategory")]
        public async Task<IActionResult> SetupUnitOfMeasure([FromBody]UnitOfMeasureViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty Sabmit", ApiResponseCodes.INVALID_REQUEST);

            var result = await _unitOfMeasureService.SetupUnitOfMeasure(viewModel, this.CurrentUser.UserId);

            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }

            return this.ApiResponse<UnitOfMeasureViewModel>(viewModel, "check Item was setup successfully.", ApiResponseCodes.OK);
        }



        [HttpPost]
        //[Route("GetAllCategory")]

        public async Task<IActionResult> GetAllUnitOfMeasure([FromBody]SearchUnitOfMeasureViewModel viewModel)
        {
            if (viewModel.PageIndex == -1 || viewModel.PageSize == -1)
                return this.ApiResponse<string>(null, $"{viewModel.PageIndex} or {viewModel.PageSize} can not be -1", ApiResponseCodes.INVALID_REQUEST);

            var result = await _unitOfMeasureService.GetAllUnitOfMeasure(viewModel);

            if ((result.Code != ApiResponseCodes.OK))
            {
                return base.ApiResponse<string>(null, result.Description,
                    ApiResponseCodes.EXCEPTION, 1);
            }
            if (result.Payload == null)
            {
                return this.ApiResponse<List<UnitOfMeasureListViewModel>>(result.Payload, "Record not Found.", ApiResponseCodes.NOT_FOUND);

            }
            return this.ApiResponse<List<UnitOfMeasureListViewModel>>(result.Payload, "successful.", ApiResponseCodes.OK);

        }



        [HttpGet]
        public async Task<IActionResult> GetUnitOfMeasureById(Guid id)
        {

            var result = await _unitOfMeasureService.GetUnitOfMeasureById(id: id);

            if ((result.Code != ApiResponseCodes.OK))
            {
                return base.ApiResponse<string>(null, result.Description,
                    ApiResponseCodes.INVALID_REQUEST, 1);
            }

            if (result.Payload == null)
            {
                return this.ApiResponse<UnitOfMeasureListViewModel>(result.Payload, "No record found.", ApiResponseCodes.NOT_FOUND);

            }
            return this.ApiResponse<UnitOfMeasureListViewModel>(result.Payload, "successful.", ApiResponseCodes.OK);

        }



        [HttpPost]
        public async Task<IActionResult> EditUnitOfMeasure([FromBody]UnitOfMeasureEditViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);

            var result = await _unitOfMeasureService.EditUnitOfMeasure(viewModel, this.CurrentUser.UserId);


            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }
            return this.ApiResponse<UnitOfMeasureEditViewModel>(viewModel, "successful.", ApiResponseCodes.OK);

        }



        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]UnitOfMeasureEditViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);

            var result = await _unitOfMeasureService.DeleteUnitOfMeasure(Guid.Parse(viewModel.Id), this.CurrentUser.UserId);


            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }
            return this.ApiResponse<UnitOfMeasureEditViewModel>(viewModel, "successful.", ApiResponseCodes.OK);

        }
    }
}
