using Logic.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiEndpoint.Helpers
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NotFoundException: //Custom exception
                    this.setContext(HttpStatusCode.NotFound, context).Wait();
                    break;
                case ArgumentException:
                    this.setContext(HttpStatusCode.UnprocessableEntity, context).Wait();
                    break;
                case InvalidOperationException:
                    this.setContext(HttpStatusCode.Conflict, context).Wait();
                    break;
                default:

                    this.setContext(HttpStatusCode.InternalServerError, context).Wait();
                    break;
            }

            base.OnException(context);
        }

        private async Task setContext(HttpStatusCode statusCode, ExceptionContext context)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.HttpContext.Response.Headers["Expires"] = "-1";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";

            context.HttpContext.Response.StatusCode = (int)statusCode;

            //Plain text
            context.HttpContext.Response.ContentType = "text/plain; charset=utf-8";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(context.Exception.Message));
            ReadOnlyMemory<byte> readOnlyMemory = new ReadOnlyMemory<byte>(stream.ToArray());

            await context.HttpContext.Response.Body.WriteAsync(readOnlyMemory); //Has to be async

            context.ExceptionHandled = true;
        }
    }
}
