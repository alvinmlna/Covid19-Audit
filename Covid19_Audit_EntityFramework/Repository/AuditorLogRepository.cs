using Covid19_Audit_EntityFramework.Entity;
using Covid19_Audit_EntityFramework.Repository.Interface;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Audit_EntityFramework.Repository
{
    public class AuditorLogRepository : GenericRepository<AuditorLog>, IAuditorLogRepository
    {
        public AuditorLogRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
