using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Tark.AspNetCore.StartupReporting.Services;

namespace Tark.AspNetCore.StartupReporting
{
    public class StartupReportingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly StartupReportingService _startupReportingService;
        private readonly StartupMiddlewareConfiguration _configuration;

        public StartupReportingMiddleware(RequestDelegate next, StartupReportingService startupReportingService, StartupMiddlewareConfiguration configuration)
        {
            _next = next;
            _startupReportingService = startupReportingService;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Equals(_configuration.ReportRoute))
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(_startupReportingService.GetStartupStatus()));
            }
            else if (IsApplicationInitialized() || IsExemptedRoute(context))
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                await context.Response.WriteAsync("Application starting up.");
            }
        }

        private bool IsExemptedRoute(HttpContext context)
        {
            return _configuration.ExemptedRoutes.Any(exemptedRoute => new Regex(exemptedRoute, RegexOptions.IgnoreCase).IsMatch(context.Request.Path.Value));
        }

        private bool IsApplicationInitialized()
        {
            return _startupReportingService.Status == StartupStatus.Started;
        }
    }
}
