using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using ASP.NET_CORE_3_Chapter_15.Services;

namespace ASP.NET_CORE_3_Chapter_15
{
    public class WeatherEndpoint
    {
        //private IResponseFormatter formatter;

        //public WeatherEndpoint(IResponseFormatter responseFormatter) {
        //    formatter = responseFormatter;
        //}

        public async Task Endpoint(HttpContext context,
                IResponseFormatter formatter)
        {
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}
