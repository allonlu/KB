using KB.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.EntityFramework
{
    /// <summary>
    /// 一个空的UnitOfWork，不做任何事情。
    /// </summary>
    public class InnerUnitOfWork : IUnitOfWork
    {
       
        public void Complete()
        {
           
        }

        public void Dispose()
        {
        }

        public void SetSiteId(int siteId)
        {
           
        }
    }
}
