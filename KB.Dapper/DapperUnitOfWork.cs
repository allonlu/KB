using KB.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Transactions;

namespace KB.Dapper
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private TransactionScope _transactionScope;
        private IDbConnection _connection;
        private int _siteId;
        public DapperUnitOfWork(System.Transactions.IsolationLevel isolationLevel,IDbConnection connection)
        {
            var transactionScopeOption = new  TransactionScopeOption();
            _transactionScope = new TransactionScope(transactionScopeOption, new TransactionOptions() {IsolationLevel=isolationLevel });
            _connection = connection;
            _connection.Open();
        }

        public event EventHandler Disposed;

        public void Complete()
        {
            _transactionScope.Complete();
            
        }

        public void Dispose()
        {
            _transactionScope.Dispose();
            _connection.Close();
        }

        public int GetSiteId()
        {
            return _siteId;
        }

        public void SetSiteId(int siteId)
        {
            _siteId = siteId;
        }
    }
}
