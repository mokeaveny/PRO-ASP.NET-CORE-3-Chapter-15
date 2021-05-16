using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASP.NET_CORE_3_Chapter_15.Services
{
    public class TimeResponseFormatter : IResponseFormatter
    {
        private ITimeStamper stamper;

        public TimeResponseFormatter(ITimeStamper timeStamper)
        {
            stamper = timeStamper;
        }

        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"{stamper.TimeStamp}: {content}");
        }
    }
}
