
using Comm100.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Runtime.Logging
{
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            System.Diagnostics.Debug.Print("Error:" + message);
        }

        public void Info(string message)
        {
            System.Diagnostics.Debug.Print("Info:" + message);
        }

        public void Warn(string message)
        {
            System.Diagnostics.Debug.Print("Warn:" + message);
        }
    }
}
