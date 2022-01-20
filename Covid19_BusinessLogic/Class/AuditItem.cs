using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Class
{
    public class AuditItem
    {
        public string Item { get; set; }
        public bool Result { get; set; }
        public string Remark { get; set; }
        public string UploadedFile { get; set; }
    }
}
