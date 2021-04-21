using System;
using System.Collections.Generic;
using System.Text;
using Tark.AspNetCore.StartupReporting.Services;

namespace Tark.AspNetCore.StartupReporting
{
    public class StartupStatusReport
    {
        public StartupStatusReport(StartupStatus status, IEnumerable<Dependency> dependencies)
        {
            this.Dependencies = dependencies;
            this.Status = status;
        }

        public IEnumerable<Dependency> Dependencies { get; private set; }
        public StartupStatus Status { get; private set; }
    }
}
