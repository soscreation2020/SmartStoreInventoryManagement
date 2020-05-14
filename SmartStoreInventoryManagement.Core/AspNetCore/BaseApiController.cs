using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStoreInventoryManagement.Core.Enums;
using SmartStoreInventoryManagement.Core.Security;
using SmartStoreInventoryManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SmartStoreInventoryManagement.Core.AspNetCore
{
    public class BaseApiController : ControllerBase
    {
        protected UserPrincipal CurrentUser
        {
            get
            {
                return new UserPrincipal(User as ClaimsPrincipal);
            }
        }

        public IActionResult ApiResponse<T>(T data = default(T), string[] message = null,
           ApiResponseCodes codes = ApiResponseCodes.OK, int? totalCount = 0) where T : class
        {
            ApiResponse<T> response = new ApiResponse<T>
            {
                Payload = data,
                Code = codes,
                Errors = message?.ToList()
            };

            response.TotalCount = totalCount ?? 0;
            return ReturnHttpMessage(codes, response);
        }

        public IActionResult ApiResponse<T>(T data = default(T), string message = "",
        ApiResponseCodes codes = ApiResponseCodes.OK, int? totalCount = 0) where T : class
        {
            ApiResponse<T> response = new ApiResponse<T>
            {
                Description = message,
                Payload = data,
                Code = codes
            };

            response.TotalCount = totalCount ?? 0;
            return ReturnHttpMessage(codes, response);
        }

        private IActionResult ReturnHttpMessage<T>(ApiResponseCodes codes, ApiResponse<T> response) where T : class
        {
            switch (codes)
            {
                case ApiResponseCodes.EXCEPTION:
                    return this.StatusCode(StatusCodes.Status500InternalServerError, response);
                case ApiResponseCodes.UNAUTHORIZED:
                    return this.StatusCode(StatusCodes.Status401Unauthorized, response);
                case ApiResponseCodes.NOT_FOUND:
                case ApiResponseCodes.INVALID_REQUEST:
                case ApiResponseCodes.ERROR:
                case ApiResponseCodes.FAIL:
                    return this.StatusCode(StatusCodes.Status400BadRequest, response);
                case ApiResponseCodes.OK:
                default:
                    return Ok(response);
            }
        }

        protected ApiResponse<IEnumerable<string>> GetModelStateValidationErrorsAsList()
        {
            var response = new ApiResponse<IEnumerable<string>>
            {
                Code = ApiResponseCodes.ERROR
            };
            var message = ModelState.Values.SelectMany(a => a.Errors).Select(e => e.ErrorMessage);
            var list = new List<string>();
            list.AddRange(message);
            response.Payload = list;
            return response;
        }

        protected string GetModelStateValidationErrors()
        {
            string message = string.Join("; ", ModelState.Values
                                    .SelectMany(a => a.Errors)
                                    .Select(e => e.ErrorMessage));
            return message;
        }

        protected string GetModelStateValidationError()
        {
            string message = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
            return message;
        }

        protected IActionResult HandleError(Exception ex, string customErrorMessage = null)
        {
            ApiResponse<string> rsp = new ApiResponse<string>();
            rsp.Code = Enums.ApiResponseCodes.ERROR;
#if DEBUG
            rsp.Description = $"Error: {(ex?.InnerException?.Message ?? ex.Message)} --> {ex?.StackTrace}";
            return Ok(rsp);
#else
             rsp.Description = customErrorMessage ?? "An error occurred while processing your request!";
             return Ok(rsp);
#endif
        }

    }
}
