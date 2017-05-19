using System.Collections.Generic;
using Domain.Entities;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class TodaysTrainingsViewModel
    {
        public bool IsAdmin { get; set; }
        public IEnumerable<Training> TodaysTranings { get; set; }

       
    }
}
