using System;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Domain.Uow
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork Begin();
        IUnitOfWork Begin(IsolationLevel isolationLevel);
    }
}
