using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tark.AspNetCore.StartupReporting.Services
{
    public class StartupReportingService
    {
        private readonly List<Dependency> _dependencies = new List<Dependency>();
        private StartupStatus _status = StartupStatus.Starting;

        public void UpdateStartupState(StartupStatus status)
        {
            this._status = status;
        }

        public StartupStatus Status => this._status;

        public IEnumerable<Dependency> Dependencies =>
            _dependencies.AsEnumerable();

        public StartupStatusReport GetStartupStatus()
        {
            return new StartupStatusReport(_status, _dependencies);
        }

        public void UpdateDependencyStatus(string name, DependencyStatus status)
        {
            _dependencies.First(dependency => dependency.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .Status = status;
        }

        internal void RegisterDependencies(params Dependency[] dependencies)
        {
            _dependencies.AddRange(dependencies);
        }
    }
}
