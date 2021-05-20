using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Routing;
using ASP.NET_CORE_3_Chapter_15.Services;

namespace ASP.NET_CORE_3_Chapter_15
{
    public class SumEndpoint
    {
        public async Task Endpoint(HttpContext context, IDistributedCache cache,
            IResponseFormatter formatter, LinkGenerator generator)
        {
            int count = int.Parse((string)context.Request.RouteValues["count"]);
            long total = 0;
            for (int i = 1; i <= count; i++)
            {
                total += i;
            }
            string totalString = $"({ DateTime.Now.ToLongTimeString() }) {total}";

            context.Response.Headers["Cache-Control"] = "public, max-age=120";

            string url = generator.GetPathByRouteValues(context, null,
                new { count = count });

            await formatter.Format(context,
                $"<div>({DateTime.Now.ToLongTimeString()}) Total for {count}"
                + $" values:</div><div>{totalString}</div>"
                + $"<a href={url}>Reload</a>");
        }
    }
}
