using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid19_Audit.Viewmodel.Report
{
    public class AuditReportViewModel
    {
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }

        public string Status { get; set; }
    }
}