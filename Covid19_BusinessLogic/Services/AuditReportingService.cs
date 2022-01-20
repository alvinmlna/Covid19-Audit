using Covid19_Audit_EntityFramework;
using Covid19_BusinessLogic.Services.Interfaces;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Services
{
    public class AuditReportingService : IAuditReportingService
    {
        public UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<CheckLists> GetAuditChecklistReportsByDate(DateTime from, DateTime to)
        {
            return _unitOfWork.ChecklistRepository.Get()
                .Where(x => x.Audit.AuditDate != null && x.Audit.AuditDate.Date >= from.Date && x.Audit.AuditDate.Date <= to.Date);
        }

        public IEnumerable<Feedback> GetAuditFeedbackReportsByDate(DateTime from, DateTime to)
        {
            return _unitOfWork.FeedbackRepository.Get()
                .Where(x => x.Audit.AuditDate != null && x.Audit.AuditDate.Date >= from.Date && x.Audit.AuditDate.Date <= to.Date);
        }
    }
}
