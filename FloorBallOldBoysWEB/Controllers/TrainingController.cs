using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.Utilites;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FloorBallOldBoysWEB.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITraningService _traningService;
        private readonly IUserService _userService;
        private readonly UserManager<UserAccount> _userManager;

        public TrainingController(ITraningService traningService, IUserService userService, UserManager<UserAccount> userManager)
        {
            _traningService = traningService;
            _userService = userService;
            _userManager = userManager;

        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [Authorize]
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
                return RedirectToAction("TodaysTrainings");
            }
            return View();
        }
        [Authorize]
        public IActionResult TodaysTrainings()
        {
            var loggedInUser = GetLoggedInUser();
            var todaysTranings = GetTodaysTranings();
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTodaysTrainingsViewModel(todaysTranings, loggedInUser);

            return View("TodayTranings", model);
        }



        [Authorize]
        public IActionResult EnrollTraining(int trainingId)
        {
            var training = _traningService.Find(trainingId);

            var user = GetLoggedInUser();
            training.EnrolledUsers.Add(new UserTraningEnrollment
            {
                TrainingId = training.Id,
                UserId = user.Id
            });
            _traningService.Update(training);
            return RedirectToAction("TodaysTrainings");
        }


        [Authorize]
        public IActionResult DismissTraining(int trainingId)
        {
            var training = _traningService.AllInclude("EnrolledUsers.User").FirstOrDefault(t => t.Id == trainingId);
            var user = GetLoggedInUser();
            var deleteEnrollments = training.EnrolledUsers.Where(ute => ute.UserId == user.Id).ToList();
            deleteEnrollments.ForEach(de => training.EnrolledUsers.Remove(de));
            _traningService.Update(training);
            return RedirectToAction("TodaysTrainings");
        }

        private User GetLoggedInUser()
        {
            var loggedInUserId = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).UserId;
            return _userService.Find(loggedInUserId);
        }
        private IEnumerable<Training> GetTodaysTranings()
        {
            return _traningService.AllInclude("EnrolledUsers.User")
                .Where(t => t.StartTime.Date == DateTime.Today);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int trainingId)
        {
            var training = _traningService.Find(trainingId);
            var model = Mapper.ModelToViewModelMapping.TrainingToTrainingViewModel(training);
            if (model is null)
            {
                return RedirectToAction(nameof(TodaysTrainings));
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int trainingId, EditTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var traning = _traningService.Find(trainingId);
                traning = Mapper.ViewModelToModelMapping.EditTrainingViewModelToTraining(model, traning);
                _traningService.Update(traning);
                return RedirectToAction("TodaysTrainings");
            }

            return View(model);
        }
    }
}
