using System.Collections.Generic;
using Domain.Entities;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.ViewModels;

namespace FloorBallOldBoysWEB.Utilites
{
    internal class ModelToViewModelMapper
    {
        public TrainingsViewModel TrainingsToTrainingsViewModel(
            IEnumerable<Training> todaysTranings, User loggedInUser)
        {
            return new TrainingsViewModel
            {
                Tranings = todaysTranings,
                IsAdmin = loggedInUser.IsAdmin

            };
        }

        public EditTrainingViewModel TrainingToTrainingViewModel(Training training)
        {
            return new EditTrainingViewModel
            {
               Id=training.Id,
               Date = training.Date.Date,
               StartTime = training.StartTime,
               EndTime = training.EndTime,
               Info = training.Info,
               Location = training.Location,
               IsCancelled = training.IsCancelled
            };
        }
    }


}