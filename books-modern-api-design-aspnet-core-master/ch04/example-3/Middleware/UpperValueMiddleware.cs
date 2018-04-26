using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware
{
    public class UpperValueMiddleware
    {
        private readonly RequestDelegate next;
        public UpperValueMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var value = context.Items["value"].ToString();
            context.Items["value"] = value.ToUpper();
            await next(context);
        }
    }


}
