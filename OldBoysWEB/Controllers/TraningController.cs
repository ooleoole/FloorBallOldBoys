using System;
using DomainLayer.Entities;
using DomainLayer.Services;
using Microsoft.AspNetCore.Mvc;
using OldBoysWEB.ViewModels;

namespace OldBoysWEB.Controllers
{
    public class TraningController : Controller
    {
        private ITraningService _traningService;
        private readonly IUserService _userService;

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
        public IActionResult Create(CreateTraningViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newTraning = new Traning
                {
                    StartTime = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.StartTime.Hour, model.StartTime.Minute, 0),
                    EndTime = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.EndTime.Hour, model.EndTime.Minute, 0),
                    Info = model.Info,
                    Creator = (Admin)_userService.Find(4)

                };
                _traningService.Add(newTraning);
                return View();
            }
            return View();
        }
    }
}
