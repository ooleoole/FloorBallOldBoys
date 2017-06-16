using Domain.Entities;

namespace FloorBallOldBoysWEB.Utilites
{
    public interface ISession
    {
        User GetLoggedInUser(string userName);
    }
}