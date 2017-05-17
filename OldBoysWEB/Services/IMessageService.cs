using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldBoysWEB.Services
{
    public interface IMessagesService
    {
        string GetMessage();
        void SetMessage(string mess);
    }

}
