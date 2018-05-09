using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // .ToConstant


            //IKernel kernel = new StandardKernel();
            ////Register a Console Logger Constant value

            //http://thebrainyprofessionals.com/2014/02/10/using-toconstant-in-ninject/

            //// .ToConstant will create instance only once and same object is used by the kernal

            //kernel.Bind<ILogger>().ToConstant(new ConsoleLogger());
            //kernel.Bind<ILogger>().ToConstant(new DebugLogger());

            //// .To this will create instance for each call

            ////kernel.Bind<ILogger>().To<ConsoleLogger>();
            ////kernel.Bind<ILogger>().To<DebugLogger>();

            ////Get the Logger
            //IEnumerable<ILogger> loggers = kernel.GetAll<ILogger>();
            //foreach (var logger in loggers)
            //{
            //    logger.Log("hello");
            //}

            ////get the loggers again and then invoke log
            ////It should the same constant loggers registered and not create new instances.
            //loggers = kernel.GetAll<ILogger>();
            //foreach (var logger in loggers)
            //{
            //    logger.Log("hello");
            //}



            var kernel = new StandardKernel();
            kernel.Bind<ILogger>().ToConstructor(x => new ConsoleLogger());

            var aClass = kernel.Get<ILogger>();



            Console.ReadKey();
        }
    }
}
