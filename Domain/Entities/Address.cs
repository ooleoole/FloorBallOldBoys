using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
