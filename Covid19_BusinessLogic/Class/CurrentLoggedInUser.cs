using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Class
{
    public class CurrentLoggedInUser
    {
        public string BadgeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Partners { get; set; }
        public DateTime DateLogin { get; set; }
    }
}
