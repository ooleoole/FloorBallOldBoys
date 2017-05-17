using System;
using System.Linq;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    public class TraningController : Controller
    {
        private readonly ITraningService _traningService;
        private IUserService _userService
            ;

        public TraningController(ITraningService traningService, IUserService userService)
        {
            _traningService = traningService;
            _userService = userService;

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(CreateTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newTraning = new Training
                {
                    StartTime = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.StartTime.Hour, model.StartTime.Minute, 0),
                    EndTime = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.EndTime.Hour, model.EndTime.Minute, 0),
                    Info = model.Info,
                    CreatorId = 1

                };
                _traningService.Add(newTraning);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public IActionResult TodaysTranings()
        {
            var model = new HomePageViewModel
            {
                TodaysTranings = _traningService.ChainInclude<UserTraningEnrollment>(p => p.EnrolledUsers, chainedProprty => chainedProprty.User)
                    .Where(t => t.StartTime.Date == DateTime.Today)

            };
            foreach (var traning in model.TodaysTranings)
            {
                traning.EnrolledUsers.ToList().ForEach(eu => eu.User = _userService.Find(eu.UserId));
            }
            return View("TodayTranings", model);
        }
    }
}
