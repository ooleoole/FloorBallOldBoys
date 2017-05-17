namespace DomainLayer.Entities
{
    public class UserTraningEnrollment
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TraningId { get; set; }
        public Traning Traning { get; set; }

    }
}
