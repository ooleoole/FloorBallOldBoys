using System;
using Domain.Entities;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class TrainingsViewModel
    {
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public string Info { get; set; }
        public User Creator { get; set; }
    }
}
