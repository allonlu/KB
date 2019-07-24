using KB.Domain.Entities;
using KB.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace KB.EntityFramework
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction ;
        private DbContext _dbContext;
        private bool _isCommit;
        private int _siteId;
        public EFUnitOfWork(DbContext dbContext, TransactionOptions options)
        {

           
            _transaction = dbContext.Database.BeginTransaction();
            _isCommit = false;
            _dbContext = dbContext;
           
         
        }

        public event  EventHandler Disposed;
        public void Complete()
        {
            _transaction.Commit();
            _isCommit = true;
        }

        public void Dispose()
        {
            Disposed(this, null);
            if (!_isCommit)
                _transaction.Rollback();
            _transaction.Dispose();
        }

        public void SetSiteId(int siteId)
        {
            _siteId = siteId;
            var databaseName = GetDatabase(siteId);

            ChangeDatabase(databaseName);
            ChangeTableName(siteId);
        }

        private void ChangeTableName(int siteId)
        {
            foreach (IEntityType entityType in _dbContext.Model.GetEntityTypes())
            {
                ///如果entity继承IBelongToSite接口，就会更换表名
                if (typeof(IBelongToSite).IsAssignableFrom(entityType.ClrType))
                {
                    if (entityType.Relational() is RelationalEntityTypeAnnotations relational)
                    {
                        relational.TableName = CreateTableName(relational, siteId);
                    }
                }
            }
        }
        private string  CreateTableName(RelationalEntityTypeAnnotations relational, int siteId)
        {
            ///没有变化，等于原来的。
            return relational.TableName;
        }
        private void ChangeDatabase(string databaseName)
        {
            var connection = _dbContext.Database.GetDbConnection();
            if (connection.State.HasFlag(ConnectionState.Open))
            {
                connection.ChangeDatabase(databaseName);
            }
            else
            {
                var connectionString = Regex.Replace(connection.ConnectionString.Replace(" ", ""), @"(?<=[Dd]atabase=)\w+(?=;)", databaseName, RegexOptions.Singleline);
                connection.ConnectionString = connectionString;
            }
        }

        private string GetDatabase(int siteId)
        {
            return "KbTest1";

        }


        public int GetSiteId()
        {
            return _siteId;
        }
    }
}
