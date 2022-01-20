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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }

        public User Login(string badgeId)
        {
            //if true then user is registered
            return dbSet.FirstOrDefault(x => x.BadgeId == badgeId);
        }
    }
}
