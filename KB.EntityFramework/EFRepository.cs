using KB.Domain.Entities;
using KB.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KB.EntityFramework
{



    public  class Repository<TEntity> : IRepository<TEntity> where TEntity :class, IEntity,new()
    { 
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dataSet;
        public Repository(DbContext dbContext)
        {
            _dataSet = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dataSet;
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
           
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
               Delete(entity);

            }
            return _dbContext.SaveChanges();

        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Any(predicate);
        }
    }
    }

