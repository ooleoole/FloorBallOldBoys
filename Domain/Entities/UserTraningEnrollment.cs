namespace Domain.Entities
{
    public class UserTraningEnrollment
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TraningId { get; set; }
        public Training Training { get; set; }

    }
}
