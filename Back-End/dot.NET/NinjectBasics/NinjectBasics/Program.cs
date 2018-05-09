using Ninject;
using NinjectBasics.DependencyResolver;
using NinjectBasics.Services;
using NinjectBasics.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectBasics
{
    class Program
    {



        static void Main(string[] args)
        {
            // Without Ninject

            //IMessageService smsservice = new SmsService();

            //NotificationService notifyService = new NotificationService(smsservice);

            //notifyService.NotifyUser();

            // using Ninject
            
            IKernel kernal = new StandardKernel(new DemoModule());

            // Get Named Bindings 

            //IMessageService mailservice = kernal.Get<IMessageService>("MailBinding");
            //IMessageService smsservice = kernal.Get<IMessageService>("SmsBinding");

            NotificationService notifyService = kernal.Get<NotificationService>();

            notifyService.NotifyUser();

            notifyService.CheckPropertyInjection();

            Console.ReadKey();

        }
    }
}
