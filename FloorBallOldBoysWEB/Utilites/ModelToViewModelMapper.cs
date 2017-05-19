using System.Collections.Generic;
using Domain.Entities;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.ViewModels;

namespace FloorBallOldBoysWEB.Utilites
{
    internal class ModelToViewModelMapper
    {
        public TodaysTrainingsViewModel TrainingsToTodaysTrainingsViewModel(
            IEnumerable<Training> todaysTranings, User loggedInUser)
        {
            return new TodaysTrainingsViewModel
            {
                TodaysTranings = todaysTranings,
                IsAdmin = loggedInUser.IsAdmin

            };
        }
    }
}