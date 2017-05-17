using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Entities;
using DomainLayer.Services;
using Microsoft.AspNetCore.Mvc;
using OldBoysWEB.ViewModels;

namespace OldBoysWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITraningService _traningService;
        private readonly IUserService _userService;

        public HomeController(ITraningService traningService, IUserService userService)
        {
            _traningService = traningService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                TodaysTranings = _traningService.ChainInclude<UserTraningEnrollment>(p=>p.EnrolledUsers,chainedProprty=>chainedProprty.User)
                    .Where(t => t.StartTime.Date == DateTime.Today)

            };
            foreach (var traning in model.TodaysTranings)
            {
                traning.EnrolledUsers.ToList().ForEach(eu => eu.User = _userService.Find(eu.UserId));
            }
            return View("Index", model);
        }
    }
}

