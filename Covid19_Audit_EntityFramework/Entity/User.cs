using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string BadgeId { get; set; }
        public string FullName { get; set; }
    }
}
