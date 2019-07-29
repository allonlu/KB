using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Comm100.Domain;
using Comm100.Domain.Services;
using KB.Domain.DomainServices;

namespace KB.Domain
{
    public class DomainIocInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.DomainServiceRegister(typeof(DomainIocInitializer).Assembly);
        }
    }
}
