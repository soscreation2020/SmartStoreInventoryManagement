using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SmartStoreInventoryManagement.Core.Enums;
using SmartStoreInventoryManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.AspNetCore.Filters
{
    public class SharedExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger _logger;

        public SharedExceptionAttribute(IHostingEnvironment env, ILogger<SharedExceptionAttribute> logger)
        {
            _env = env;
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var apiError = new ApiResponse<string>();
            apiError.Code = ApiResponseCodes.EXCEPTION;

            if (context.Exception is UnauthorizedAccessException)
            {
                apiError.Code = ApiResponseCodes.UNAUTHORIZED;
                apiError.Description = ApiResponseCodes.UNAUTHORIZED.GetDescription();
                context.HttpContext.Response.StatusCode = 401;
                _logger.LogError("Unauthorized Access in Controller Filter.");
            }
            else
            {
                var msg = string.Empty;
                var stack = string.Empty;
                if (_env.IsDevelopment())
                {
                    msg = context.Exception.GetBaseException().Message;
                    stack = context.Exception.StackTrace;
                }
                else
                {
                    stack = msg = "An unhandled error occurred.";
                }

                apiError.Payload = msg;
                apiError.Description = stack;
                context.HttpContext.Response.StatusCode = 500;
                _logger.LogError(new EventId(0), context.Exception, msg);
            }

            context.Result = new ObjectResult(apiError);
            base.OnException(context);
        }
    }
}
