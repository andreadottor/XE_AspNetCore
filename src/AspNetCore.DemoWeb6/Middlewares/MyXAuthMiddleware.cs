using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.DemoWeb6.Middlewares
{
    public class MyXAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public MyXAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var xAuth = context.Request.Headers["X-Auth"];

            if (string.Compare(xAuth, "core_is_better") != 0)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return context.Response.WriteAsync("Unathorized");
            }

            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }
}