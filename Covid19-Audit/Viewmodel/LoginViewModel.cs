using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid19_Audit.Viewmodel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please insert badge id")]
        public string Username { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage ="Please select your partner")]
        public IEnumerable<string> PartnerNames { get; set; }
    }
}