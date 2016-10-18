using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationApps.Infrastructure
{
    //在ASp.net Core中通过契约注入中间件，而不是和以前一样的接口
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private UptimeService uptimeService;

        public ContentMiddleware(RequestDelegate next, UptimeService uptimeService)
        {
            nextDelegate = next;
            this.uptimeService = uptimeService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware" + $"(uptime:{uptimeService.Uptime})", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
