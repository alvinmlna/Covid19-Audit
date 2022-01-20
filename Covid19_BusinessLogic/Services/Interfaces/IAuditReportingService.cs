using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Services.Interfaces
{
    public interface IAuditReportingService
    {
        IEnumerable<CheckLists> GetAuditChecklistReportsByDate(DateTime from, DateTime to);
        IEnumerable<Feedback> GetAuditFeedbackReportsByDate(DateTime from, DateTime to);
    }
}
