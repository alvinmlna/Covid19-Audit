using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Class.Report
{
    public class AuditChecklistReportViewModel
    {
        public int TransactionId { get; set; }
        public DateTime AuditDate { get; set; }
        public string Auditor { get; set; }
        public string AuditorPartner1 { get; set; }
        public string AuditorPartner2 { get; set; }
        public string Location { get; set; }
        public string AuditCode { get; set; }
        public string FocusArea { get; set; }
        public string AuditItem { get; set; }
        public bool Result { get; set; }
        public string ResultView {
            get
            {
                if (Result)
                {
                    return "Pass";
                } else
                {
                    return "Fail";
                }
            }
        }
        public string Category { get; set; }
        public string Remark { get; set; }
        public string UploadedPicture { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}
