using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Training
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        public bool IsCancelled { get; set; }
        public string Info { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public ICollection<UserTraningEnrollment> EnrolledUsers { get; set; }= new List<UserTraningEnrollment>();
        public ICollection<UserTraningAttendance> ActualAttendance { get; set; } = new List<UserTraningAttendance>();
    }
}
