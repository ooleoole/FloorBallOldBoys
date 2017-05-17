using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OldBoysWEB.Services
{
   
    public class MessagesService : IMessagesService
    {

        
        private readonly IConfiguration _conf;

        public MessagesService(IConfiguration conf)
        {
            _conf = conf;
            
        }

        public string GetMessage()
        {
            return _conf["message"];
        }

        public void SetMessage(string mess)
        {
            _conf["message"] = mess;
        }
    }
}
