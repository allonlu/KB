
using Comm100.Domain.Ioc;
using Comm100.Runtime;
using KB.Infrastructure.Runtime.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KB.Web.Host.Controllers
{
    public class ControllerBase : Controller
    {
        public ControllerBase()
        {

            Logger =  NullLogger.Instance;
        }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public ILogger Logger { get; set; }

    }
}