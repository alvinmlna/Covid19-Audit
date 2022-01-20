using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class Audit
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime AuditDate { get; set; }

        public string Auditor { get; set; }
        public string AuditorPartner1 { get; set; }
        public string AuditorPartner2 { get; set; }

        public string AuditCodeText { get; set; }
        public string Location { get; set; }
        public DateTime SubmittedDate { get; set; } //this is auto inserted
    }
}
