using System.Collections.Generic;

namespace DomainLayer.Entities
{
    public class Admin : User
    {
        public IEnumerable<Traning> CreatedTranings { get; set; }=new List<Traning>();
    }
}
