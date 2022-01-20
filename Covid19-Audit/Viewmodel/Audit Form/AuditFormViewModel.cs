using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid19_Audit.Viewmodel
{
    public class AuditFormViewModel
    {
        public int TransactionId { get; set; }
        public string AuditorId { get; set; }
        public string AuditorName { get; set; }
        public string AuditorPartner { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AuditDate { get; set; }
        public string Location { get; set; }
        public string AuditCode { get; set; }

        public List<AuditCheckListViewModel> AuditCheckList { get; set; }
        public FeedbackViewModel FeedbackCheckList { get; set; }
    }
}