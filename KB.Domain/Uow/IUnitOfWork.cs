using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Domain.Uow
{
    public interface IUnitOfWork:IDisposable
    {

        event EventHandler Disposed;
        void SetSiteId(int siteId);
        int GetSiteId();
        void Complete();
    }
}
