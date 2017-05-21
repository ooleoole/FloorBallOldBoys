using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities;

namespace FloorBallOldBoysWEB.Utilites
{
    public interface ISession
    {
        User GetLoggedInUser(string userName);
    }
}
