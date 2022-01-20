using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class CheckLists
    {
        [Key]
        public int ChecklistId { get; set; }
        public string FocusAreaText { get; set; }

        public string QuestionText { get; set; }

        public bool Result { get; set; }
        public string Category { get; set; }
        public string Remark { get; set; }
        public string UploadedFile { get; set; }

        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
    }
}
