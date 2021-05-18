using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace ASP.NET_CORE_3_Chapter_15
{
    public class SumEndpoint
    {
        public async Task Endpoint(HttpContext context, IDistributedCache cache)
        {
            int count = int.Parse((string)context.Request.RouteValues["count"]);
            string cacheKey = $"sum_{count}";
            string totalString = await cache.GetStringAsync(cacheKey);
            if (totalString == null)
            {
                long total = 0;
                for (int i = 1; i <= count; i++)
                {
                    total += 1;
                }
                totalString = $"({ DateTime.Now.ToLongTimeString() }) {total}";
                await cache.SetStringAsync(cacheKey, totalString,
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                    });
            }
            await context.Response.WriteAsync(
                $"({DateTime.Now.ToLongTimeString()}) Total for {count}"
                + $" values:\n{totalString}\n");
        }
    }
}
