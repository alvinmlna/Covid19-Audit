using Covid19_Audit_EntityFramework.Entity;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("booth_db")
        {
        }

        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditCode> AuditCodes { get; set; }
        public DbSet<CheckLists> CheckLists { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FocusArea> FocusAreas { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditorLog> AuditorLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Covid19_Audit");
            base.OnModelCreating(modelBuilder);
        }
    }
}
