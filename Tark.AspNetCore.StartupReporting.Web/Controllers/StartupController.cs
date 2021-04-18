using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tark.AspNetCore.StartupReporting.Services;

namespace Tark.AspNetCore.StartupReporting.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartupController : ControllerBase
    {
        private readonly StartupReportingService _startupReportingService;

        public StartupController(StartupReportingService startupReportingService)
        {
            _startupReportingService = startupReportingService;
        }

        [HttpGet("{status}")]
        public ActionResult SetStartupStatus(string status)
        {
            _startupReportingService.UpdateStartupState(Enum.Parse<StartupStatus>(status, true));
            return Ok();
        }

        [HttpGet("dependencies/{dependency}/{status}")]
        public ActionResult SetStartupStatus(string dependency, string status)
        {
            _startupReportingService.UpdateDependencyStatus(dependency, Enum.Parse<DependencyStatus>(status, true));
            return Ok();
        }
    }
}