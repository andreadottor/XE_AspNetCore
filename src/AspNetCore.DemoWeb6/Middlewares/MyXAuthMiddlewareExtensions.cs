using Microsoft.AspNetCore.Builder;

namespace AspNetCore.DemoWeb6.Middlewares
{
    public static class MyXAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyXAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyXAuthMiddleware>();
        }
    }
}