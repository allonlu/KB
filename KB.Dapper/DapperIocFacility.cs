using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Comm100.Domain.Repository;
using Comm100.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace KB.Dapper
{
    public class DapperIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(


        Component.For(typeof(DbConnection))
                .UsingFactoryMethod(k => { return DbConnectionFactory.Create(); })
                .LifestyleScoped(),
 
        Component.For(typeof(IRepository<>))
               .ImplementedBy(typeof(DapperRepository<>))
               .LifestyleScoped(),

        Component.For(typeof(IUnitOfWorkManager))
                 .ImplementedBy(typeof(DapperUnitOfWorkManager))
                 .LifestyleScoped()

    );
        }
    }
}
