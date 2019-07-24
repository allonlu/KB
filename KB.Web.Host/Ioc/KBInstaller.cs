using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KB.Application;
using KB.Dapper;
using KB.EntityFramework;
using KB.Infrastructure;

namespace KB.Web.Host.Ioc
{
    public class KBInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<ApplicationIocFacility>();
            //container.AddFacility<EntityFrameworkIocFacility>(); 
            container.AddFacility<DapperIocFacility>();
            container.AddFacility<InfrastructureIocFacility>();
        }
    }
}