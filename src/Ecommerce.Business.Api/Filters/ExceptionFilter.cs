using AutoMapper.Configuration;
using Ecommerce.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;

namespace Ecommerce.Business.Api.Filters
{
    public sealed class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var message = JsonConvert.SerializeObject(MessageError(context.Exception), Formatting.Indented);
            var objResponseService = new ResponseService<string>
            {
                Status = false,
                Message = HttpStatusCode.InternalServerError.ToString(),
                Data = message
            };

            context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(objResponseService, Formatting.Indented));
        }

        private static List<ResponseException> MessageError(Exception ex, int level = 30)
        {
            var listError = new List<ResponseException>();
            var counter = 1;
            while (ex != null && counter <= level)
            {
                listError.Add(new ResponseException
                {
                    ErrorLevel = counter.ToString(),
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    ErrorStackTrace = ex.StackTrace,
                    ErrorTargetSite = ex.TargetSite?.ToString(),
                    ErrorData = ex.Data
                });
                ex = ex.InnerException;
                counter++;
            }
            return listError;
        }
    }
}