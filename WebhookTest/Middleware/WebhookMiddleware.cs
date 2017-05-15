using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebhookTest.Middleware
{
    public class WebhookMiddleware
    {
        private readonly RequestDelegate _next;

        public WebhookMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains("X-GitHub-Event"))
            {
                Startup.Requested += 1;
                context.Response.StatusCode = 200;
                return;
            }

            await _next.Invoke(context);

            if (context.Request.Headers.Keys.Contains("X-Transfer-By"))
            {
                context.Response.Headers.Add("X-Transfer-Success", "true");
            }
        }
    }
}
