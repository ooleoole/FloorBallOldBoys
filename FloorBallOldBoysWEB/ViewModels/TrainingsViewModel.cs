using System.Collections.Generic;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class TrainingsViewModel
    {
        public bool IsAdmin { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<TrainingSummaryViewModel> TrainingsSummaryViewModels { get; set; }

       
    }
}
