using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DomainLayer.Entities;

namespace OldBoysWEB.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Traning> TodaysTranings { get; set; }
       
    }
}
