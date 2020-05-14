using SmartStoreInventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
    public static class ResponseMessage
    {
        public static ApiResponse<T> SuccessMessage<T>(string message, T data)
        {
            return new ApiResponse<T>
            {

                Code = ApiResponseCodes.OK,
                Description = message,
                Payload = data
            };
        }

        public static ApiResponse<T> ErrorMessage<T>(string error, ApiResponseCodes responseCodes = ApiResponseCodes.ERROR)
        {
            return new ApiResponse<T>
            {

                Code = responseCodes,
                Description = error

            };
        }
    }
}
