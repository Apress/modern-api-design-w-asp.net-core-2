using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace RequestRateLimiting
{
    public class AwesomeRateLimiterMiddleware
    {
        private const int limit = 5;
        private readonly RequestDelegate next;
        private readonly IMemoryCache requestStore;
        public AwesomeRateLimiterMiddleware(RequestDelegate next, IMemoryCache requestStore)
        {
            this.next = next;
            this.requestStore = requestStore;
        }
        public async Task Invoke(HttpContext context)
        {
            var requestKey = $"{context.Request.Method}-{context.Request.Path}";
            int hitCount = 0;
            var cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30)
            };
            if (requestStore.TryGetValue(requestKey, out hitCount))
            {
                if (hitCount < limit)
                {
                    await ProcessRequest(context, requestKey, hitCount, cacheEntryOptions);

                }
                else
                {
                    context.Response.Headers["X-Retry-After"] = cacheEntryOptions.AbsoluteExpiration?.ToString();
                    await context.Response.WriteAsync("Quota exceeded");
                }
            }
            else
            {
                await ProcessRequest(context, requestKey, hitCount, cacheEntryOptions);
            }
        }
        private async Task ProcessRequest(HttpContext context, string requestKey, int hitCount, MemoryCacheEntryOptions cacheEntryOptions)
        {
            hitCount++;
            requestStore.Set(requestKey, hitCount, cacheEntryOptions);
            context.Response.Headers["X-Rate-Limit"] = limit.ToString();
            context.Response.Headers["X-Rate-Limit-Remaining"] = (limit -
            hitCount).ToString();
            await next(context);
        }
    }
}
