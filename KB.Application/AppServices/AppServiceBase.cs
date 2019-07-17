using KB.Domain.Uow;
using KB.Infrastructure.Ioc;
using KB.Infrastructure.Runtime.Authorization;
using KB.Infrastructure.Runtime.Logging;
using KB.Infrastructure.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.AppServices
{
    public class AppServiceBase
    {

        protected IUnitOfWorkManager _unitOfWorkManager;
        public AppServiceBase(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
            Logger = new NullLogger();
        }
        /// <summary>
        /// 权限认证,不通过就抛出一个权限错误。
        /// </summary>
        /// <param name="rightName"></param>
        /// <returns></returns>
        public void Permission(string rightName)
        {
            if (!PermissionChecker.IsGranted(Session.GetAgentId(), rightName))
            {
                Logger.Info($"SiteId:{Session.GetSiteId()},AgentId:{Session.GetAgentId()},Type:PermissionCheckFail,Permission:{rightName} ");
                throw new Exception("没有权限！");
            }

        }
        protected T Run<T>(string permissionName,Func<T> func)
        {
            using(var uow = _unitOfWorkManager.Begin())
            {
               
                uow.SetSiteId(Session.GetSiteId());

               Permission(permissionName);

                var t = func();

                uow.Complete();

                return t;
            }

        }
        protected void Run(string permissionName, Action func)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {

                uow.SetSiteId(Session.GetSiteId());

                Permission(permissionName);

                func();

                uow.Complete();
            }

        }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        /// 
        [Mandatory]
        public ISession Session { get; set; }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public IPermissionChecker PermissionChecker { get; set; }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public ILogger Logger { get; set; }
    }
}
