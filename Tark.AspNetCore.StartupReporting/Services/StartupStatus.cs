using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tark.AspNetCore.StartupReporting.Services
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StartupStatus
    {
        Starting,
        Started,
        Error
    }
}
