using Castle.Core;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using KB.Application.AppServices;
using KB.Application.Interceptors;
using KB.Domain;

namespace KB.Application
{
    public class ApplicationIocFacility : AbstractFacility
    {
        protected override void Init()
        {
           Kernel.Register(
            Component.For<AppServiceInterceptor>()
                    .ImplementedBy<AppServiceInterceptor>()
                    .LifestyleTransient(),

            Classes.FromAssemblyContaining<IAppService>()
            .BasedOn<IAppService>()
            .Configure(configurer =>
            {
                configurer.Named(configurer.Implementation.Name);
                ///注册AOP拦截器
                _ = configurer.Interceptors(InterceptorReference.ForType<AppServiceInterceptor>()).Anywhere;
            })
            .WithServiceAllInterfaces()
            .LifestyleTransient()
            );
            DomainIocInitializer.Init(Kernel);
        }
    }
}
