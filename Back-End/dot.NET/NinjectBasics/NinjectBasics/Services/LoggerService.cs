using NinjectBasics.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectBasics.Services
{
    public class LoggerService : ILoggerService
    {
        public void LogInfo()
        {
            Console.WriteLine("Logger Service has Logged the Info !");
        }
    }
}
