using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19_Audit.Viewmodel.Audit_Form
{
    public class AuditItemViewModel
    {
        public int QuestionId { get; set; }

        [AllowHtml]
        public string QuestionText { get; set; }

        public string Category { get; set; }

        [Required]
        public bool? Result { get; set; }

        public string Remark { get; set; }

        public List<string> UploadedFile { get; set; }
        public List<HttpPostedFileBase> PostedFiles { get; set; }
    }
}