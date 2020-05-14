//using Microsoft.AspNetCore.Components;
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
    [Route("api/[controller]/[action]")]
    public class DepartmentsController : BaseApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;

        }


        [HttpPost]
        [Route("SetupDepartment")]
        public async Task<IActionResult> SetupDepartment([FromBody]DepartmentViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);
            
            var result = await _departmentService.SetupDepartment(viewModel, this.CurrentUser.UserId);

            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }

            return this.ApiResponse<DepartmentViewModel>(viewModel, "check Item was setup successfully.", ApiResponseCodes.OK);
        }


        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]DepartmentEditViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);

            var result = await _departmentService.EditDepartmet(viewModel, this.CurrentUser.UserId);


            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }
            return this.ApiResponse<DepartmentEditViewModel>(viewModel, "successful.", ApiResponseCodes.OK);

        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]DepartmentEditViewModel viewModel)
        {
            if (viewModel == null)
                return this.ApiResponse<string>(null, "Empty payload", ApiResponseCodes.INVALID_REQUEST);

            var result = await _departmentService.DeleteDepartment(Guid.Parse(viewModel.Id), this.CurrentUser.UserId);


            if (result.Any())
            {
                return base.ApiResponse<string>(null, result.Select(r => r.ErrorMessage).ToArray(),
                    ApiResponseCodes.INVALID_REQUEST, result.Count());
            }
            return this.ApiResponse<DepartmentEditViewModel>(viewModel, "successful.", ApiResponseCodes.OK);

        }


        [HttpPost]
        //[Route("GetAllCategory")]

        public async Task<IActionResult> GetAll([FromBody]SearchDepartmentViewModel viewModel)
        {
            if (viewModel.PageIndex == -1 || viewModel.PageSize == -1)
                return this.ApiResponse<string>(null, $"{viewModel.PageIndex} or {viewModel.PageSize} can not be -1", ApiResponseCodes.INVALID_REQUEST);

            var result = await _departmentService.GetAllDepartment(viewModel);

            if ((result.Code != ApiResponseCodes.OK))
            {
                return base.ApiResponse<string>(null, result.Description,
                    ApiResponseCodes.EXCEPTION, 1);
            }
            if (result.Payload == null)
            {
                return this.ApiResponse<List<DepartmentListViewModel>>(result.Payload, "Record not Found.", ApiResponseCodes.NOT_FOUND);

            }
            return this.ApiResponse<List<DepartmentListViewModel>>(result.Payload, "successful.", ApiResponseCodes.OK);

        }



        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {

            var result = await _departmentService.GetDepartmentById(id: id);

            if ((result.Code != ApiResponseCodes.OK))
            {
                return base.ApiResponse<string>(null, result.Description,
                    ApiResponseCodes.INVALID_REQUEST, 1);
            }

            if (result.Payload == null)
            {
                return this.ApiResponse<DepartmentListViewModel>(result.Payload, "No record found.", ApiResponseCodes.NOT_FOUND);

            }
            return this.ApiResponse<DepartmentListViewModel>(result.Payload, "successful.", ApiResponseCodes.OK);

        }

        

    }
}
