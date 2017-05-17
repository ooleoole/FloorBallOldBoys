using System.Collections.Generic;
using Domain.Entities;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Training> TodaysTranings { get; set; }
       
    }
}
