using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Audit_EntityFramework.Entity
{
    public class AuditorLog
    {
        [Key]
        public int AuditorLogId { get; set; }
        public DateTime DateAudit { get; set; }
        public string AuditorBadgeId { get; set; }
        

        public int AuditId { get; set; }

        [ForeignKey("AuditId")]
        public virtual Audit Audit { get; set; }

    }
}
