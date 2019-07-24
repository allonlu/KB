using KB.Domain.Entities;
using KB.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DapperExtensions.Sql;
using System.Data;
using DapperExtensions;
using KB.Dapper.DapperExpressionExtensions;

namespace KB.Dapper
{
    public class DapperRepository<T> : IRepository<T> where T:class,IEntity
    {
        public DbConnection _dbConnection;
        public DapperRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
           
        }
        public int Delete(int id)
        {
            var predicate = Predicates.Field<T>(f => f.Id, Operator.Eq, id);
            return  _dbConnection.Delete<T>(predicate)?1:0;

        }

        public int Delete(T entity)
        {
            return _dbConnection.Delete<T>(entity) ? 1 : 0;
        }

        public int Delete(Expression<Func<T, bool>> predicate)
        {
            var p = predicate.ToPredicateGroup<T>();
            return _dbConnection.Delete<T>(p) ? 1 : 0;
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            var p = predicate.ToPredicateGroup<T>();
            return _dbConnection.Count<T>(p) == 0 ? false:true ;
        }

        public T Get(int id)
        {
            return _dbConnection.Get<T>(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            var p = predicate.ToPredicateGroup<T>();
            return _dbConnection.GetList<T>(p).AsQueryable();
        }

        public T Insert(T entity)
        {
            var ent= _dbConnection.Insert<T>(entity);
            return Get((int)ent);
        }

        public T Update(T entity)
        {
            _dbConnection.Update<T>(entity);
            return Get(entity.Id);
        }
    }
}
