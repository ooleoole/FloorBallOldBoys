using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(LoginViewModel model)
        {
            var test = model;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
