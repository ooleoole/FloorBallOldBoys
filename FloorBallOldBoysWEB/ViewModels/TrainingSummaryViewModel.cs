using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class TrainingSummaryViewModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public bool IsCancelled { get; set; }
        public string Info { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public ICollection<UserTraningEnrollment> EnrolledUsers { get; set; } = new List<UserTraningEnrollment>();
        public ICollection<UserTraningAttendance> ActualAttendance { get; set; } = new List<UserTraningAttendance>();

        public bool IsAdmin { get; set; }
        public string ReturnUrl { get; set; }
    
    }
}
