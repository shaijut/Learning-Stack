using NinjectBasics.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectBasics.Services
{
    public class SmsService :  IMessageService
    {
        public void SendMessage()
        {
            Console.WriteLine("SMS has been Send To User !");
        }

       
    }
}
