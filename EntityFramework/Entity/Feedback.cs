using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string FeedbackContent { get; set; }
        public string Area { get; set; }
        public string Category { get; set; }
        public string UploadedFile { get; set; }

        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
    }
}
