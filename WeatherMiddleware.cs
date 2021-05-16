using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using ASP.NET_CORE_3_Chapter_15.Services;

namespace ASP.NET_CORE_3_Chapter_15
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;

        public WeatherMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context, IResponseFormatter formatter1,
                IResponseFormatter formatter2, IResponseFormatter formatter3)
        {
            if (context.Request.Path == "/middleware/class")
            {
                await formatter1.Format(context, string.Empty);
                await formatter2.Format(context, string.Empty);
                await formatter3.Format(context, string.Empty);
            }
            else
            {
                await next(context);
            }
        }
    }
}