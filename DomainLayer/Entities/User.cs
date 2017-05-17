using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(45), MinLength(2)]
        public string Firstname { get; set; }
        [MaxLength(45), MinLength(2)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(12), MinLength(12)]
        public string SocialSecurityNumber { get; set; }
        [MinLength(11)]
        public string Phonenumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Address Address { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public IEnumerable<UserTraningEnrollment> EnrolledTranings { get; set; } = new List<UserTraningEnrollment>();
        public IEnumerable<UserTraningAttendance> AttendedTranings { get; set; } = new List<UserTraningAttendance>();
    }
}
