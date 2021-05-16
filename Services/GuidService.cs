using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASP.NET_CORE_3_Chapter_15.Services
{
    public class GuidService : IResponseFormatter
    {
        private Guid guid = Guid.NewGuid();

        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"Guid: {guid}\n{content}");
        }
    }
}