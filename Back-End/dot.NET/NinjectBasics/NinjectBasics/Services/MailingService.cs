using NinjectBasics.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectBasics.Services
{
    public class MailingService : IMessageService
    {
        private ILoggerService _loggerService;
        public MailingService(ILoggerService loggerService)
        {
            this._loggerService = loggerService;

            MailLog();
        }
        public void SendMessage()
        {
            Console.WriteLine("Mail has been Send To User !");
        }


        public void MailLog()
        {
            _loggerService.LogInfo();
        }

      
    }
}
