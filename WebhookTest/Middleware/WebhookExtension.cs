using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebhookTest.Middleware
{
    public static class WebhookExtension
    {
        public static IApplicationBuilder UseWebhookMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebhookMiddleware>();
        }
    }
}
