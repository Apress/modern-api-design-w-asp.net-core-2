using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    public static class UpperValueMiddlewareExtensions
    {
        public static IApplicationBuilder UseUpperValue(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UpperValueMiddleware>();
        }
    }


}
