using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Runtime.Session
{
    public interface ISession
    {
        int GetAgentId();
        int GetSiteId();
    }
}
