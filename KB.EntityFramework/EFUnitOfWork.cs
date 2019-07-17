using KB.Domain.Uow;
using Microsoft.EntityFrameworkCore;
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
        private TransactionScope _transactionScope;
        private DbContext _dbContext;
        public EFUnitOfWork(DbContext dbContext, TransactionOptions options)
        {
            _transactionScope = new TransactionScope(TransactionScopeOption.Required, options);
            _dbContext = dbContext;
        }

        public EventHandler Disposed;
        public int Complete()
        {
            var i=_dbContext.SaveChanges();
            _transactionScope.Complete();
            return i;
        }

        public void Dispose()
        {
            Disposed(this, null);
            _transactionScope.Dispose();
        }

        public void SetSiteId(int siteId)
        {
           //根据SiteId到数据库里查找SiteId的数据库名称，变更数据库。
           //然后根据SiteId，更新实体的映射表名。
        }
    }
}
