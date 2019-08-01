using Comm100.Domain.Entity;
using Comm100.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KB.EntityFramework
{
    public  class EFRepository<TEntity> : IRepository<TEntity> where TEntity :class, IEntity,new()
    { 
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dataSet;
        public EFRepository(DbContext dbContext)
        {
            _dataSet = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) return _dataSet.AsQueryable();
            return _dataSet.Where(predicate);
        }

        public TEntity Get(int id)
        {
            
            return _dataSet.Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            _dataSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;

        }

        public int Delete(TEntity entity)
        {
            _dataSet.Remove(entity);

            return _dbContext.SaveChanges();

        }


        public TEntity Update(TEntity entity)
        {
            
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Get(entity.Id);
        }


        public int Delete(int id)
        {
            _dataSet.Remove(new TEntity() { Id = id });
           return  _dbContext.SaveChanges();

        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
           
            foreach (var entity in GetAll(predicate).ToList())
            {
               Delete(entity);

            }
            return _dbContext.SaveChanges();

        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll(predicate).Any();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) return _dataSet.Count();
            return _dataSet.Count(predicate);
        }
    }
    }

