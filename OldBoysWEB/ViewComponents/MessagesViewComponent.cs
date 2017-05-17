using System.Threading;
using Microsoft.AspNetCore.Mvc;
using OldBoysWEB.Services;

namespace OldBoysWEB.ViewComponents
{
    public class MessagesViewComponent : ViewComponent
    {
        private IMessagesService _messagesService;

        public MessagesViewComponent(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _messagesService.GetMessage();
            return View("Default", model);
        }
    }
}