﻿using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {

            return View();
        }
    }
}

