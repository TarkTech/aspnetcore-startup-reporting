
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tark.AspNetCore.StartupReporting.Services;

namespace Tark.AspNetCore.StartupReporting
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddStartupReporting(this IServiceCollection services, StartupMiddlewareConfiguration configuration = null)
        {
            if (configuration == null)
            {
                configuration = new StartupMiddlewareConfiguration();
            }

            services.AddSingleton(configuration);
            return services.AddSingleton<StartupReportingService>();
        }

        public static IApplicationBuilder UseStartupReporting(this IApplicationBuilder builder, params Dependency[] dependencies)
        {
            builder.ApplicationServices.GetRequiredService<StartupReportingService>().RegisterDependencies(dependencies);

            return builder.UseMiddleware<StartupReportingMiddleware>();
        }
    }
}
