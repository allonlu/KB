using KB.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace KB.EntityFramework
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction ;
        private DbContext _dbContext;
        private bool _isCommit;
        public EFUnitOfWork(DbContext dbContext, TransactionOptions options)
        {

           
            _transaction = dbContext.Database.BeginTransaction();
            _isCommit = false;
            _dbContext = dbContext;
           
         
        }

        public EventHandler Disposed;
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
           //根据SiteId到数据库里查找SiteId的数据库名称，变更数据库。
           //然后根据SiteId，更新实体的映射表名。
        }
    }
}
