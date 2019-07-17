using Castle.Facilities.AspNetCore;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.Web.Host.Ioc
{
    public class ServiceResolver : IServiceProvider
    {
      
            private static WindsorContainer container;
            private static IServiceProvider serviceProvider;

            public ServiceResolver(IServiceCollection services)
            {
                
                container = new WindsorContainer();

                container.Install(new KBInstaller());
                services.AddWindsor(container);
                serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
            }

        public object GetService(Type serviceType)
        {
            return serviceProvider.GetService(serviceType);
        }

    }
}
