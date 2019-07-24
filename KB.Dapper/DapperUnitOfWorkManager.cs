using KB.Domain.Uow;
using KB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Transactions;

namespace KB.Dapper
{
    public class DapperUnitOfWorkManager : IUnitOfWorkManager
    {
        private DbConnection _connection;
        private IUnitOfWork _outerUow;
        public DapperUnitOfWorkManager(DbConnection connection)
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(CustomPluralizedMapper<>);
            _connection = connection; 
        }
        
        public IUnitOfWork Begin()
        {
            return Begin(System.Transactions.IsolationLevel.ReadCommitted);
        }

        public IUnitOfWork Begin(System.Transactions.IsolationLevel isolationLevel)
        {
            if (_outerUow != null)
                return new InnerUnitOfWork();
            var option = new TransactionOptions
            {
                IsolationLevel = isolationLevel
            };

            var uow = new DapperUnitOfWork(isolationLevel, _connection);

            uow.Disposed += (sender, e) =>
            {
                _outerUow = null;
            };

            _outerUow = uow;

            return _outerUow;

        }
    }
}
