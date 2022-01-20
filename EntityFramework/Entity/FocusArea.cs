using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class FocusArea
    {
        public int FocusAreaId { get; set; }
        public string AreaName { get; set; }
        public virtual ICollection<AuditCode> AuditCodes { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
