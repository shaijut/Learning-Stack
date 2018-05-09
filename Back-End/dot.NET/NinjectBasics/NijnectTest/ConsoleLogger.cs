using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijnectTest
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
            Console.WriteLine("Console Logger Created...");
        }

        public void Log(string message)
        {
            Console.WriteLine("Message from Console Logger-" + message);
        }
    }
}
