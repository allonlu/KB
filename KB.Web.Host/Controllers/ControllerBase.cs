using Castle.Core.Logging;
using KB.Infrastructure.ActionResult;
using KB.Infrastructure.Ioc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KB.Web.Host.Controllers
{
    public class ControllerBase : Controller
    {
        public ControllerBase()
        {

            Logger = new NullLogger();
        }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public ILogger Logger { get; set; }

        protected ActionResult Run(Func<ActionResult> action)
        {
            try
            {
                return action();
                
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return Json(ActionResultHelper.Fail(e));

            }
        }
    }
}