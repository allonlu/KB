using KB.Infrastructure.Exceptions;
using KB.Infrastructure.Ioc;
using KB.Infrastructure.Runtime.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KB.Web.Host.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        [Mandatory]
        public static ILogger Logger { get; set; }

        public void OnException(ExceptionContext context)
        {
            //Logger.Error(context.Exception.Message);

            if (!(context.ActionDescriptor is ControllerActionDescriptor))
            {
                return;
            }

            context.HttpContext.Response.StatusCode = GetStatusCode(context);

            var myException = context.Exception as MyException;
            if (myException == null)
                context.Result = new ObjectResult(new { ErrorCode = 10009, Message = context.Exception.Message });
            else
                context.Result = new ObjectResult(new { ErrorCode = myException.ErrorCode, Message=myException.Message });

            context.Exception = null;
        }

        private int GetStatusCode(ExceptionContext context)
        {
            //通过检查Context.Exception的类型，返回不同的StatusCode.
           if(context.Exception is EntityNotFoundException)
            {
                return (int)HttpStatusCode.NotFound;
            }
           if(context.Exception is AuthorizationException)
            {
                return (int)HttpStatusCode.Unauthorized;
            }

            return (int)HttpStatusCode.InternalServerError;
        }
     }
}
