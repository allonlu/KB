using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.Web.Host.Ioc
{
    public class ServiceResolver
    {
      
            private static WindsorContainer container;
            private static IServiceProvider serviceProvider;

            public ServiceResolver(IServiceCollection services)
            {
                
                container = new WindsorContainer();

                container.Install(new KBInstaller());
            
                serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
            }

            public IServiceProvider GetServiceProvider()
            {
                return serviceProvider;
            }
        
    }
}
