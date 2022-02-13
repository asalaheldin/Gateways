using Gateways.Ground;
using Gateways.UseCases.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Api.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    { 
        public async Task OnExceptionAsync(ExceptionContext exceptionContext)
        {
            //don't raise error if exception can be handled
            var exceptionHandled = await HandleKnownExceptions(exceptionContext);
            if (exceptionHandled)
                return;

           //To Do 
           //Add custom behavior to log other exceptions and produce a user friendly error message

        }

        #region helper methods
        private static async Task<bool> HandleKnownExceptions(ExceptionContext exceptionContext)
        {
            bool isExceptionHandled = false;
            if (exceptionContext.Exception is ValidationException)
            {
                var validationException = exceptionContext.Exception as ValidationException;
                if (validationException.Errors != null && validationException.Errors.Any())
                {
                    var errorsContent = Encoding.UTF8.GetBytes(new { errors = validationException.Errors.SelectMany(err => err.Value) }.SerializeModelObject());
                    var response = exceptionContext.HttpContext.Response;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.ContentType = "application/json";
                    await response.Body.WriteAsync(errorsContent, 0, errorsContent.Length);
                }

                isExceptionHandled = true;
            }

            return isExceptionHandled;
        }

        #endregion
    }
}
