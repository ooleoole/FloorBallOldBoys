using System.Collections.Generic;

namespace Domain.Entities
{
    public class Admin : User
    {
        public IEnumerable<Training> CreatedTranings { get; set; }=new List<Training>();
    }
}
