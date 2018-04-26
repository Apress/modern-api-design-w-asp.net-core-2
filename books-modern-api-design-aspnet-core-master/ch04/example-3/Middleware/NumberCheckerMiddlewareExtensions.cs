using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    public static class NumberCheckerMiddlewareExtensions
    {
        public static IApplicationBuilder UseNumberChecker(this IApplicationBuilder app)
        {
            return app.UseMiddleware<NumberCheckerMiddleware>();
        }
    }


}
