using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_CoreApp
{
    public class MainMiddelware
    {
        private RequestDelegate _next;
        public MainMiddelware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {

            await context.Response.WriteAsync("HellO Pargev");
           await  _next.Invoke(context);
        }
    }
}
