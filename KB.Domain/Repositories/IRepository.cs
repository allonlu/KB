﻿using KB.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KB.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity:IEntity
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        bool Exists(Expression<Func<TEntity, bool>> predicate);


    }
}