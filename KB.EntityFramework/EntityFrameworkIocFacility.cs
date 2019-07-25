
using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using KB.Domain.DomainServices;
using KB.Domain.Repositories;
using KB.Domain.Uow;
using KB.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace KB.EntityFramework
{
    public class EntityFrameworkIocFacility: AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Component.For(typeof(DbContext))
                       .ImplementedBy(typeof(KBDataContext))
                       .LifestyleScoped(),
                Component.For(typeof(IRepository<>))
                       .ImplementedBy(typeof(EFRepository<>))
                       .LifestyleScoped(),
                Component.For(typeof(IUnitOfWorkManager))
                         .ImplementedBy(typeof(EFUnitOfWorkManager))
                         .LifestyleScoped()

            ) ;
        }
    }
}
