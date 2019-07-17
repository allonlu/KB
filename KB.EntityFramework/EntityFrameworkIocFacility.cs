﻿
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
                        .UsingFactoryMethod(k => { return DbContextFactory.Create(k); })
                        .LifestyleScoped(),

                Component.For(typeof(IRepository<>))
                       .ImplementedBy(typeof(Repository<>))
                       .LifestyleScoped(),

                Component.For(typeof(IUnitOfWorkManager))
                         .ImplementedBy(typeof(EFUnitOfWorkManager))
                         .LifestyleScoped()

            ) ;
        }
    }
}