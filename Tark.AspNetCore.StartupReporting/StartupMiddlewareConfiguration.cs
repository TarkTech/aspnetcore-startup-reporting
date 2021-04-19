using System;
using System.Collections.Generic;
using System.Text;

namespace Tark.AspNetCore.StartupReporting
{
    public class StartupMiddlewareConfiguration
    {
        public StartupMiddlewareConfiguration()
        {
            ReportRoute = "/api/startup-status";
;
            ExemptedRoutes = new string[0];
        }
        public string ReportRoute { get; set; }
        public string[] ExemptedRoutes { get; set; }
    }
}
