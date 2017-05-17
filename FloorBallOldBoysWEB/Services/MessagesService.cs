using Microsoft.Extensions.Configuration;

namespace FloorBallOldBoysWEB.Services
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
