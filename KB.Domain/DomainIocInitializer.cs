using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using KB.Domain.DomainServices;
using KB.Domain.Repositories;

namespace KB.Domain
{
    public class DomainIocInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Register(

                Classes.FromAssemblyContaining<IDomainService>()
                        .BasedOn<IDomainService>()
                        .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                        .WithServiceAllInterfaces()
                        .LifestyleTransient()
            );
        }
    }
}
