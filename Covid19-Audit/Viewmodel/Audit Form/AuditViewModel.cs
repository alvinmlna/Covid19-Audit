using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid19_Audit.Viewmodel.Audit_Form
{
    public class AuditViewModel
    {
        [Required(ErrorMessage = "The Audit Date Field is required")]
        public DateTime AuditDate { get; set; }
        public string Location { get; set; }

        [Required(ErrorMessage = "The Audit Code Field is required")]
        public string AuditCode { get; set; }
    }
}