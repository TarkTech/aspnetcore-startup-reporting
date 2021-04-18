using System;
using System.Collections.Generic;
using System.Text;
using Tark.AspNetCore.StartupReporting.Services;

namespace Tark.AspNetCore.StartupReporting
{
    public class StartupStatusReport
    {
        public StartupStatusReport(StartupStatus statusReport, IEnumerable<Dependency> dependencies)
        {
            this.Dependencies = dependencies;
            this.StatusReport = statusReport;
        }

        public IEnumerable<Dependency> Dependencies { get; private set; }
        public StartupStatus StatusReport { get; private set; }
    }
}
