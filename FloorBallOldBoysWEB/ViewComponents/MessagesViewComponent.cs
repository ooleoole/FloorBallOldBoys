using FloorBallOldBoysWEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.ViewComponents
{
    public class MessagesViewComponent : ViewComponent
    {
        private readonly IMessagesService _messagesService;

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