using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    public class DebugLogger : ILogger
    {



        public DebugLogger()
        {
            Console.WriteLine("Debug Logger Created...");
        }
        public void Log(string message)
        {
            Console.WriteLine("Message from DebugLogger-" + message);
        }
    }
}
