using Covid19_BusinessLogic.Class;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Services.Interfaces
{
    public interface IUserServices
    {
        CurrentLoggedInUser GetCurrentLoggedInUser();

        IEnumerable<User> GetUsers();

        bool Login(string badgeId, IEnumerable<string> partners);
        bool LoginAdmin(string badgeId, IEnumerable<string> partners);


        User FindByBadgeId(string badgeId);
    }
}
