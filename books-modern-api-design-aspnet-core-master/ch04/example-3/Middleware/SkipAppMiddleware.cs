using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware
{
    public class SkipAppMiddleware
    {
        private readonly RequestDelegate next;
        public SkipAppMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Skip the line!");
        }
    }


}
