using Covid19_BusinessLogic.Class;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_BusinessLogic.Services.Interfaces
{
    public interface IAuditFormServices
    {

        IEnumerable<Audit> GetAllAudits();
        AuditCode GetAuditCheckListByCode(string auditCode);
        void SubmitAudit(Audit audit, List<CheckLists> checkLists, Feedback feedback);

        bool IsAuditorAlreadySubmit(Audit audit);
    }
}
