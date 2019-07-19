using Castle.DynamicProxy;
using KB.Domain.Uow;
using KB.Infrastructure.Ioc;
using KB.Infrastructure.Runtime.Authorization;
using KB.Infrastructure.Runtime.Logging;
using KB.Infrastructure.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KB.Application.Interceptor
{
    public class AppServiceInterceptor : IInterceptor
    {

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

        private IUnitOfWorkManager _unitOfWorkMananger;
        public AppServiceInterceptor(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkMananger = unitOfWorkManager;
        }
        public void Intercept(IInvocation invocation)
        {
            try
            {

                CheckPermission(GetMethod(invocation));

                using (var uow = _unitOfWorkMananger.Begin())
                {

                    uow.SetSiteId(Session.GetSiteId());
                    invocation.Proceed();
                    uow.Complete();
            }

            }catch(Exception e)
            {
                Logger.Error(e.Message);
                throw e;
            }
        }
        private MethodInfo GetMethod(IInvocation invocation)
        {
            try
            {
                return invocation.MethodInvocationTarget;
            }
            catch
            {
                return invocation.GetConcreteMethod();
            }
        }
        private void CheckPermission(MethodInfo method)
        {
            var attrs = method.GetCustomAttributes(true).OfType<PermissionAttribute>().ToArray();
            if (attrs.Length == 0) {
                throw new Exception("没有配置权限！");
            } 
            var permissionName = attrs[0].Name;
            if (!PermissionChecker.IsGranted(Session.GetAgentId(), permissionName))
            {
                Logger.Info($"SiteId:{Session.GetSiteId()},AgentId:{Session.GetAgentId()},Type:PermissionCheckFail,Permission:{permissionName} ");
                throw new Exception("没有权限！");
            }
            Logger.Info($"SiteId:{Session.GetSiteId()},AgentId:{Session.GetAgentId()},Type:PermissionCheckSuccess,Permission:{permissionName} ");
        }
    }
    
}
