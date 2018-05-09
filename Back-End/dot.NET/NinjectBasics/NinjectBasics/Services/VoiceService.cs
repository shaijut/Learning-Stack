using NinjectBasics.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectBasics.Services
{
    public class VoiceService : IMessageService
    {
        private string _logMessage;
        public VoiceService(string logMessage)
        {
            this._logMessage = logMessage;

            SmsLog();
        }

        public void SendMessage()
        {
            Console.WriteLine("Voice Message has been Send To User !");
        }

        public void SmsLog()
        {
            Console.WriteLine("Voice Message Logged using {0}", _logMessage);
        }
    }
}
