using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid19_Audit.Viewmodel
{
    public class FeedbackViewModel
    {
        public string FeedbackItem { get; set; }
        public string Area { get; set; }
        public string Category { get; set; }
        public string UploadedFile { get; set; }
        public List<HttpPostedFileBase> PostedFiles { get; set; }
    }
}