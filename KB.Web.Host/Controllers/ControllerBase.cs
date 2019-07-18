
using KB.Infrastructure.ActionResult;
using KB.Infrastructure.Ioc;
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

            Logger = new NullLogger();
        }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public ILogger Logger { get; set; }

        protected MyActionResult<T> Run<T>(Func<MyActionResult<T>> action)
        {
            try
            {
                return action();
                
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return ActionResultHelper.Fail<T>(e);

            }
        }

        protected IActionResult Run(Func<IActionResult> action)
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
        protected void Run(Action action)
        {
            try
            {
                 action();

            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }
    }
}