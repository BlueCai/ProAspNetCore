﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Infrastructure
{
    public class LegacyRoute : IRouter
    {
        private string[] urls;

        public LegacyRoute(params string[] targetURls)
        {
            this.urls = targetURls;
        }

        public Task RouteAsync(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if(urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.Handler = async ctx =>
                {
                    HttpResponse response = ctx.Response;
                    byte[] bytes = System.Text.Encoding.ASCII.GetBytes($"URL: {requestedUrl}");
                    await response.Body.WriteAsync(bytes, 0, bytes.Length);
                };
            }

            return Task.CompletedTask;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
