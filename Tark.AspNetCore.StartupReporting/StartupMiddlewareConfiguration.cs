using System;
using System.Collections.Generic;
using System.Text;

namespace Tark.AspNetCore.StartupReporting
{
    public class StartupMiddlewareConfiguration
    {
        public string ReportRoute { get; set; }
        public string[] ExemptedRoutes { get; set; }
    }
}
