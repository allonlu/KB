using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Runtime.Session
{
    public class Session : ISession
    {
        public int GetAgentId()
        {
            return 1;
        }

        public int GetSiteId()
        {
            return 1231;
        }
    }
}
