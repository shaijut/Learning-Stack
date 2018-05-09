using Ninject;
using NinjectBasics.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectBasics.Services
{
    public class NotificationService
    {
        // Multi Injection with all implementation of single interface
        //private IMessageService[] _messageService;

        public string WhenClassHasSomePropertyName { get; set; }

        private IMessageService _messageService;

        public NotificationService(IMessageService messageService)
       {

            this._messageService = messageService;
       }


        public void NotifyUser()
        {
            //foreach(IMessageService message in this._messageService)

            _messageService.SendMessage();
        }


        // Property and Method Injection

        // Property Injection

        [Inject]
        public SmsService sms { get; set; }

        // Method Injection
        [Inject]
        public void TestSMS()
        {
           

            Console.WriteLine("TestSMS Method Injected while Getting NotificationService Instance ");
        }

        public void CheckPropertyInjection()
        {
            if(sms!= null)
            {
                Console.WriteLine("Sms Property Injected");

            }

            
        }

    }
}
