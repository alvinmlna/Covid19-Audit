using Covid19_Audit.Viewmodel.Audit_Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19_Audit.Viewmodel
{
    public class AuditCheckListViewModel
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public List<AuditItemViewModel> AuditItems { get; set; }
    }
}