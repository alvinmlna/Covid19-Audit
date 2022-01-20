using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class Audit
    {
        public int TransactionId { get; set; }
        public string Auditor { get; set; }
        public string AuditorPartner { get; set; }
        public string AuditCode { get; set; }
        public string Location { get; set; }
        public DateTime SubmittedDate { get; set; }
        
        public virtual List<Feedback> Feedbacks { get; set; }
    }
}
