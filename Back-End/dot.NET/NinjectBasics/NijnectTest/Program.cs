using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijnectTest
{
    class Program
    {

        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            //Register a Console Logger Constant value
            kernel.Bind<ILogger>().ToConstant(new ConsoleLogger());
            //Get the Logger
            kernel.Get<ILogger>().Log("Hello");
            //it gets the same logger
            kernel.Get<ILogger>().Log("Hello2");
        }


    }
}
