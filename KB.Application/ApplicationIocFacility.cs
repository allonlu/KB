using Castle.Core;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Comm100.Application;
using KB.Domain;

namespace KB.Application
{
    public class ApplicationIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.AppServiceRegister(this.GetType().Assembly);

            DomainIocInitializer.Init(Kernel);
        }
    }
}
