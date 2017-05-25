using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.Utilites;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
                model.Creator = LoggedInUser;
                var newTraning = Mapper.ViewModelToModelMapping.CreateTrainingViewModelToTraining(model);
                _traningService.Add(newTraning);
                return RedirectToAction("TodaysTrainings");
            }
            return View(model);
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
        public IActionResult Edit(int trainingId, string returnUrl)
        {
            var training = _traningService.Find(trainingId);
            var model = Mapper.ModelToViewModelMapping.TrainingToTrainingViewModel(training);
            
            if (model is null)
                return Redirect(returnUrl);

            model.ReturnUrl = returnUrl;
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
                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }

        private IEnumerable<Training> GetTodaysTranings()
        {
            return _traningService.AllInclude("EnrolledUsers.User")
                .Where(t => t.Date.Date == DateTime.Today);
        }


        public IActionResult Delete(int trainingId, string returnUrl)
        {
            var training = _traningService.Find(trainingId);
            if (training is null)
                return Redirect(returnUrl);

            _traningService.Delete(training);
            return Redirect(returnUrl);
        }
    }
}
