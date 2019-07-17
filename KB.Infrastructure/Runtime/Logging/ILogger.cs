using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Runtime.Logging
{
    public interface ILogger
    {
        void Info(string messsage);
        void Warn(string message);
        void Error(string message);
    }
}
