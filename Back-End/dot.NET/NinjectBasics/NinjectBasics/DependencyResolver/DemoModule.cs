using Ninject.Modules;
using NinjectBasics.Services;
using NinjectBasics.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectBasics.DependencyResolver
{
    public class DemoModule : NinjectModule
    {

        public override void Load()
        {

            // Normal Binding

            //Bind<ILoggerService>().To<LoggerService>();

            //Option 1. Named Bindings to get Intance by speciying the name

            //Bind<IMessageService>().To<MailingService>().Named("MailBinding");
            //Bind<IMessageService>().To<SmsService>().Named("SmsBinding");

            //Option 2. Contextual Binding , Used for Conditional Binding , Only Create Instance when Condition is true

            // Some methods to do Contextual Binding :

            //1.  using type binding , use this binding only on injections on NotificationService

            Bind<IMessageService>().To<MailingService>().WhenInjectedInto(typeof(NotificationService));

            //2. using request binding , use this binding only if meets specified condition

            //Bind<IMessageService>().To<MailingService>().When(request => (((System.Reflection.PropertyInfo[])((System.Reflection.TypeInfo)((request.Target.Member).ReflectedType)).DeclaredProperties)[0]).Name.Contains("WhenClassHasSomePropertyName"));


            // Option 3. WithConstructorArgument

            // Pass the required parameter value in the constructor of a class while Niject creates its Instance of that class

            //string logMessage = "WithConstructorArgument";

            //Bind<IMessageService>().To<VoiceService>().WithConstructorArgument("logMessage", logMessage);

            // Bindings


        }

    }
}
