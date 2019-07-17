using KB.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KB.Domain.DomainServices
{
    public class DomainServiceBase
    {
        
        protected IUnitOfWorkManager _unitOfWorkManager;
        public DomainServiceBase(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }

    }
}
