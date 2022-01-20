using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class CheckLists
    {
        public int ChecklistId { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public bool Result { get; set; }
        public string Remark { get; set; }
        public string UploadedFile { get; set; }


        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
    }
}
