using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class AuditCode
    {
        [Key]

        public int AuditCodeId { get; set; }
        public string AuditCodeText { get; set; }
        public virtual ICollection<FocusArea> FocusAreas { get; set; }
    }
}
