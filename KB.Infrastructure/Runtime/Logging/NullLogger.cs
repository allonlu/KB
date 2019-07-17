using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Runtime.Logging
{
    public class NullLogger : ILogger
    {
        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string messsage)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }
    }
}
