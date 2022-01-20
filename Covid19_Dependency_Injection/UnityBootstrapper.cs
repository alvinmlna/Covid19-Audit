using Covid19_BusinessLogic.Services;
using Covid19_BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Covid19_Dependency_Injection
{
    public class UnityBootstrapper
    {
        public static UnityContainer Register()
        {
            var container = new UnityContainer();

            container.RegisterType<IAuditFormServices, AuditFormServices>();
            container.RegisterType<IUserServices, UserServices>();
            container.RegisterType<IAuditReportingService, AuditReportingService>();

            return container;
        }
    }
}
