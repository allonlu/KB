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
