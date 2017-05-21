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

namespace FloorBallOldBoysWEB.Controllers
{


    public class TrainingController : Controller
    {
        private readonly ITraningService _traningService;
        private readonly ISession _session;
        private User _loggedInUser;
        private User LoggedInUser => _loggedInUser ?? (_loggedInUser = _session.GetLoggedInUser(User.Identity.Name));

        public TrainingController(ITraningService traningService, ISession session)
        {
            _traningService = traningService;
            _session = session;
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
            
            var todaysTranings = GetTodaysTranings();
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTrainingsViewModel(todaysTranings, LoggedInUser);
            model.ReturnUrl = Url.Action(nameof(TodaysTrainings));
            return View("TodayTranings", model);
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAllTrainings()
        {
            
            var allTrainings = _traningService.AllInclude("EnrolledUsers.User", "ActualAttendance.User");
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTrainingsViewModel(allTrainings, LoggedInUser);
            model.ReturnUrl = Url.Action(nameof(GetAllTrainings));
            return View("AllTrainings", model);
        }


        [Authorize]
        public IActionResult EnrollTraining(int trainingId, string returnUrl)
        {
            var training = _traningService.Find(trainingId);
            training.EnrolledUsers.Add(new UserTraningEnrollment
            {
                TrainingId = training.Id,
                UserId = LoggedInUser.Id
            });
            _traningService.Update(training);
            return Redirect(returnUrl);
        }


        [Authorize]
        public IActionResult DismissTraining(int trainingId, string returnUrl)
        {
            var training = _traningService.AllInclude("EnrolledUsers.User").FirstOrDefault(t => t.Id == trainingId);
            var deleteEnrollments = training.EnrolledUsers.Where(ute => ute.UserId == LoggedInUser.Id).ToList();
            deleteEnrollments.ForEach(de => training.EnrolledUsers.Remove(de));
            _traningService.Update(training);
            return Redirect(returnUrl);
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
        public IActionResult Edit(int trainingId, string returnUrl, EditTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var traning = _traningService.Find(trainingId);
                traning = Mapper.ViewModelToModelMapping.EditTrainingViewModelToTraining(model, traning);
                _traningService.Update(traning);
                return Redirect(returnUrl);
            }

            return View(model);
        }

        private IEnumerable<Training> GetTodaysTranings()
        {
            return _traningService.AllInclude("EnrolledUsers.User")
                .Where(t => t.Date.Date == DateTime.Today);
        }


    }
}
