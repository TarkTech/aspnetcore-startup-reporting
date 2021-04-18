using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tark.AspNetCore.StartupReporting.Services
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DependencyStatus
    {
        Waiting,
        Available,
        Error
    }

    public class Dependency
    {
        public Dependency(string name, DependencyStatus status)
        {
            Name = name;
            Status = status;
        }

        public string Name { get; set; }
        public DependencyStatus Status { get; set; }
    }
}
