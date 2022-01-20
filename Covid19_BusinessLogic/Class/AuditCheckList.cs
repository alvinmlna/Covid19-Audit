using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Class
{
    public class AuditCheckList
    {
        public string ItemTitle { get; set; }
        public List<AuditItem> AuditItems { get; set; }
    }
}
