﻿using Comm100.Domain.Uow;
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
        private int _siteId = 0;

        public event EventHandler Disposed;

        public void Complete()
        {
           
        }

        public void Dispose()
        {
        }

        public void SetSiteId(int siteId)
        {
            _siteId = siteId;
        }
        public int GetSiteId() {
            return _siteId;
        }
    }
}
