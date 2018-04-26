using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    public static class SkipAppMiddlewareExtensions
    {
        public static IApplicationBuilder UseSkipApp(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SkipAppMiddleware>();
        }
    }


}
