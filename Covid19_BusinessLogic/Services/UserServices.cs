using Covid19_Audit_EntityFramework;
using Covid19_BusinessLogic.Class;
using Covid19_BusinessLogic.Constants;
using Covid19_BusinessLogic.Services.Interfaces;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Covid19_BusinessLogic.Services
{
    public class UserServices : IUserServices
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public User FindByBadgeId(string badgeId)
        {
           return _unitOfWork.UserRepository.Login(badgeId);
        }

        public CurrentLoggedInUser GetCurrentLoggedInUser()
        {
            CurrentLoggedInUser currentLoggedInUser = new CurrentLoggedInUser
            {
                BadgeId = "Anonymous",
                Name = "Anonymous",
                Partners = new List<string> { "Anonymous" }
            };

            if(HttpContext.Current.Session[SessionConstants.CURRENT_USER] != null)
            {
                return HttpContext.Current.Session[SessionConstants.CURRENT_USER] as CurrentLoggedInUser;
            }

            return currentLoggedInUser;
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.UserRepository.Get();
        }

        public bool Login(string badgeId, IEnumerable<string> partners)
        {
            var result2 =  _unitOfWork.UserRepository.Get();
            var result =  _unitOfWork.UserRepository.Login(badgeId);

            if (result != null)
            {
                CurrentLoggedInUser loggedInuser = new CurrentLoggedInUser
                {
                    BadgeId = badgeId,
                    Name = result.FullName,
                    Partners = partners,
                    DateLogin = DateTime.Now
                };
                HttpContext.Current.Session[SessionConstants.CURRENT_USER] = loggedInuser;
            }
            return result != null;
        }

        public bool LoginAdmin(string badgeId, IEnumerable<string> partners)
        {
            var result = _unitOfWork.UserRepository.Login(badgeId);

            if (result != null && (result?.FullName.Contains("Admin") ?? false))
            {
                CurrentLoggedInUser loggedInuser = new CurrentLoggedInUser
                {
                    BadgeId = badgeId,
                    Name = result.FullName,
                    Partners = partners,
                    DateLogin = DateTime.Now
                };
                HttpContext.Current.Session[SessionConstants.CURRENT_USER] = loggedInuser;


                return true;
            }
            return false;
        }
    }
}
