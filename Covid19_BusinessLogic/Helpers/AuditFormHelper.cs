using Covid19_BusinessLogic.Class;
using Covid19_BusinessLogic.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Covid19_BusinessLogic.Helpers
{
    public static class AuditFormHelper
    {
        public static List<string> GetAllLoggedInUser()
        {
            List<string> _currentUser = new List<string>();

            if (HttpContext.Current.Session[SessionConstants.CURRENT_USER] != null)
            {
                CurrentLoggedInUser currentUser = HttpContext.Current.Session[SessionConstants.CURRENT_USER] as CurrentLoggedInUser;

                _currentUser.Add(currentUser.BadgeId);

                foreach (var partner in currentUser.Partners)
                {
                    _currentUser.Add(partner);
                }
            }

            return _currentUser;
        }

        public static bool IsEmpty(this string var)
        {
            var value = var.Trim();

            if (value != "" || String.IsNullOrEmpty(value) == false || String.IsNullOrWhiteSpace(value) == false)
            {
                return false;
            }

            return true;
        }

        public static void LogoutUser()
        {
            if (HttpContext.Current.Session[SessionConstants.CURRENT_USER] != null)
            {
                HttpContext.Current.Session[SessionConstants.CURRENT_USER] = null;
            }
        }
    }
}
