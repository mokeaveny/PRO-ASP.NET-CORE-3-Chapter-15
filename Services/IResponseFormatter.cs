using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASP.NET_CORE_3_Chapter_15.Services
{
    public interface IResponseFormatter
    {

        Task Format(HttpContext context, string content);
        public bool RichOutput => false;
    }
}
