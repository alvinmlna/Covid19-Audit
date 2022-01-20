using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Class.Report
{
    public class AuditFeedbackReportViewModel
    {
        public int TransactionId { get; set; }
        public DateTime AuditDate { get; set; }
        public string Auditor { get; set; }
        public string AuditorPartner1 { get; set; }
        public string AuditorPartner2 { get; set; }
        public string Location { get; set; }
        public string AuditCode { get; set; }
        public string FocusArea { get; set; }
        public string FeedbackContent { get; set; }
        public string Category { get; set; }
        public string UploadedPicture { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}
