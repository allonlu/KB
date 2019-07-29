
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Comm100.Runtime;
using KB.Infrastructure.Runtime.Authorization;
using KB.Infrastructure.Runtime.Logging;
using KB.Infrastructure.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure
{
    public class InfrastructureIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Component.For(typeof(ILogger)).ImplementedBy(typeof(Logger))
                         .LifestyleScoped(),
                Component.For(typeof(ISession)).ImplementedBy(typeof(Session))
                             .LifestyleScoped(),
                Component.For(typeof(IPermissionChecker)).ImplementedBy(typeof(PermissionChecker))
                             .LifestyleScoped());
        }
    }
}
