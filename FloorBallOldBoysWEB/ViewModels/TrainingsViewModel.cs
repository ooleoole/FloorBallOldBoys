using System.Collections.Generic;
using Domain.Entities;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class TrainingsViewModel
    {
        public bool IsAdmin { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<Training> Tranings { get; set; }

       
    }
}
