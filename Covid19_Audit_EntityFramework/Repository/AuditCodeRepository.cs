using Covid19_Audit_EntityFramework.Repository.Interface;
using EntityFramework;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Audit_EntityFramework.Repository
{
    public class AuditCodeRepository : GenericRepository<AuditCode>, IAuditCodeRepository
    {
        public AuditCodeRepository(ApplicationDBContext context) : base(context)
        {
        }

        public AuditCode FindByCode(string auditCode)
        {
            return dbSet.FirstOrDefault(x => x.AuditCodeText == auditCode);
        }
    }
}
