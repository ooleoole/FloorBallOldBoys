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
        private readonly ITrainingService _trainingService;
        private readonly ISession _session;
        private User _loggedInUser;
        private User LoggedInUser => _loggedInUser ?? (_loggedInUser = _session.GetLoggedInUser(User.Identity.Name));

        public TrainingController(ITrainingService trainingService, ISession session)
        {
            _trainingService = trainingService;
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
                _trainingService.Add(newTraning);
                return RedirectToAction("TodaysTrainings");
            }
            return View(model);
        }
        [Authorize]
        public IActionResult TodaysTrainings()
        {

            var todaysTranings =_trainingService.GetTodaysTrainings();
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTrainingsViewModel(todaysTranings, LoggedInUser);
            
            return View("TodayTranings", model);
        }
        //[HttpGet]
        //[Authorize]
        //public IActionResult GetAllTrainings()
        //{

        //    var allTrainings = _trainingService.AllInclude("EnrolledUsers.User", "ActualAttendance.User");
        //    var model = Mapper.ModelToViewModelMapping
        //        .TrainingsToTrainingsViewModel(allTrainings, LoggedInUser);
        //    model.ReturnUrl = Url.Action(nameof(GetAllTrainings));
        //    return View("AllTrainings", model);
        //}


        //[Authorize]
        //public IActionResult EnrollTraining(int trainingId, string returnUrl)
        //{
        //    var training = _trainingService.Find(trainingId);
        //    training.EnrolledUsers.Add(new UserTraningEnrollment
        //    {
        //        TrainingId = training.Id,
        //        UserId = LoggedInUser.Id
        //    });
        //    _trainingService.Update(training);
        //    return Redirect(returnUrl);
        //}


        //[Authorize]
        //public IActionResult DismissTraining(int trainingId, string returnUrl)
        //{
        //    var training = _trainingService.AllInclude("EnrolledUsers.User").FirstOrDefault(t => t.Id == trainingId);
        //    var deleteEnrollments = training.EnrolledUsers.Where(ute => ute.UserId == LoggedInUser.Id).ToList();
        //    deleteEnrollments.ForEach(de => training.EnrolledUsers.Remove(de));
        //    _trainingService.Update(training);
        //    return Redirect(returnUrl);
        //}


        //[HttpGet]
        //[Authorize]
        //public IActionResult Edit(int trainingId, string returnUrl)
        //{
        //    var training = _trainingService.Find(trainingId);
        //    var model = Mapper.ModelToViewModelMapping.TrainingToTrainingViewModel(training);
            
        //    if (model is null)
        //        return Redirect(returnUrl);

        //    model.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        //[HttpPost]
        //[Authorize]
        //public IActionResult Edit(int trainingId, EditTrainingViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var traning = _trainingService.Find(trainingId);
        //        traning = Mapper.ViewModelToModelMapping.EditTrainingViewModelToTraining(model, traning);
        //        _trainingService.Update(traning);
        //        return Redirect(model.ReturnUrl);
        //    }

        //    return View(model);
        //}

       

        //public IActionResult Delete(int trainingId, string returnUrl)
        //{
        //    var training = _trainingService.Find(trainingId);
        //    if (training is null)
        //        return Redirect(returnUrl);

        //    _trainingService.Delete(training);
        //    return Redirect(returnUrl);
        //}
    }
}
