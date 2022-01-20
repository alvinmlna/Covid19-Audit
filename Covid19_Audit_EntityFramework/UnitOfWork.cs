using Covid19_Audit_EntityFramework.Repository;
using EntityFramework;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Audit_EntityFramework
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDBContext context = new ApplicationDBContext();
        private AuditRepository auditRepository;
        private AuditCodeRepository auditCodeRepository;
        private UserRepository userRepository;
        private FeedbackRepository feedbackRepository;
        private ChecklistRepository checklistRepository;
        private AuditorLogRepository auditorLogRepository;


        public AuditRepository AuditRepository
        {
            get
            {
                if (this.auditRepository == null)
                {
                    this.auditRepository = new AuditRepository(context);
                }
                return auditRepository;
            }
        }
        public AuditCodeRepository AuditCodeRepository
        {
            get
            {
                if (this.auditCodeRepository == null)
                {
                    this.auditCodeRepository = new AuditCodeRepository(context);
                }
                return auditCodeRepository;
            }
        }
        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }
        public FeedbackRepository FeedbackRepository
        {
            get
            {
                if (this.feedbackRepository == null)
                {
                    this.feedbackRepository = new FeedbackRepository(context);
                }
                return feedbackRepository;
            }
        }
        public ChecklistRepository ChecklistRepository
        {
            get
            {
                if (this.checklistRepository == null)
                {
                    this.checklistRepository = new ChecklistRepository(context);
                }
                return checklistRepository;
            }
        }
        public AuditorLogRepository AuditorLogRepository
        {
            get
            {
                if (this.auditorLogRepository == null)
                {
                    this.auditorLogRepository = new AuditorLogRepository(context);
                }
                return auditorLogRepository;
            }
        }





        public int Save()
        {
           return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
