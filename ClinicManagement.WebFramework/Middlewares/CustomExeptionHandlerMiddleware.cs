﻿using ClinicManagement.Common;
using ClinicManagement.Common.Exceptions;
using ClinicManagement.WebFramework.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
namespace ClinicManagement.WebFramework.Middlewares
{
    #region Register ExtentionHandler in startup
    public static class CustomExeptionHandlerMiddlewareExtesions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExeptionHandlerMiddleware>();
        }
    }
    #endregion
    public class CustomExeptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        public ILogger<CustomExeptionHandlerMiddleware> Logger { get; }

        public CustomExeptionHandlerMiddleware
            (
                RequestDelegate Next,
                IHostEnvironment env,
                ILogger<CustomExeptionHandlerMiddleware> logger
            )
        {
            _next = Next;
            _env = env;
            Logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string message = null;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            ApiResultStatusCode apiResultStatusCode = ApiResultStatusCode.ServerError;
            try
            {
                await _next(httpContext);
            }
            catch (AppException ex)
            {
                Logger.LogError(ex, ex.Message);
                httpStatusCode = ex.HttpStatusCode;
                apiResultStatusCode = ex.ApiStatusCode;
                if (_env.IsDevelopment())
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>
                    {
                        ["Exception"] = ex.Message,
                        ["StackTrace"] = ex.StackTrace,
                    };
                    if (ex.InnerException != null)
                    {
                        dic.Add("InnerException.Exception", ex.InnerException.Message);
                        dic.Add("InnerException.StachTrace", ex.InnerException.StackTrace);
                    }
                    if (ex.AdditionalData != null)
                        dic.Add("AdditionalData", JsonConvert.SerializeObject(ex.AdditionalData));
                    message = JsonConvert.SerializeObject(dic);
                }
                else
                    message = ex.Message;
                await WriteToResponseAsync();
            }
            catch (UnauthorizedAccessException exception)
            {
                Logger.LogError(exception, exception.Message);
                SetUnAuthorizeResponse(exception);
                await WriteToResponseAsync();
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.Message);

                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    message = JsonConvert.SerializeObject(dic);
                }
                await WriteToResponseAsync();
            }

            async Task WriteToResponseAsync()
            {
                if (httpContext.Response.HasStarted)
                    throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

                ApiResult result = new ApiResult(false, apiResultStatusCode, message);
                string json = JsonConvert.SerializeObject(result);


                httpContext.Response.StatusCode = (int)httpStatusCode;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(json);
            }

            void SetUnAuthorizeResponse(Exception exception)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                apiResultStatusCode = ApiResultStatusCode.UnAuthorized;

                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace
                    };
                    message = JsonConvert.SerializeObject(dic);
                }
            }
        }
    }
}
