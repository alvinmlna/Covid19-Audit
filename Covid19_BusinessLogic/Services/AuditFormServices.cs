using Covid19_Audit_EntityFramework;
using Covid19_Audit_EntityFramework.Entity;
using Covid19_BusinessLogic.Class;
using Covid19_BusinessLogic.Constants;
using Covid19_BusinessLogic.Helpers;
using Covid19_BusinessLogic.Services.Interfaces;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Covid19_BusinessLogic.Services
{

//    - Login Menu
//Auditor name + badge id
//tidak bisa submit 2x dihari dengan kode yang sama
//tambah deskripsi audit code
//ganti font label


//- Checklist form
//alert = Please complete all of audit checklists
//max file : 3mb

//- table absensi
//  tanggal, nama
//  tanggal, nama
    public class AuditFormServices : IAuditFormServices
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IUserServices userServices;


        public AuditFormServices(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        public IEnumerable<Audit> GetAllAudits()
        {
            return _unitOfWork.AuditRepository.Get();
        }

        public AuditCode GetAuditCheckListByCode(string auditCode)
        {
            return _unitOfWork.AuditCodeRepository.FindByCode(auditCode);
        }

        public void SubmitAudit(Audit audit, List<CheckLists> checkLists, Feedback feedback)
        {
            var currentUser = userServices.GetCurrentLoggedInUser();

            audit.Auditor = currentUser.BadgeId;

            var auditorPartner = currentUser.Partners.ToArray();

            audit.AuditorPartner1 = auditorPartner[0];
            audit.AuditorPartner2 = (auditorPartner.Length > 1) ? auditorPartner[1] : "";

            _unitOfWork.AuditRepository.Insert(audit);

            var isSaved = _unitOfWork.Save();

            if (isSaved > 0)
            {
                foreach (var checklist in checkLists)
                {
                    checklist.Audit = audit;
                    _unitOfWork.ChecklistRepository.Insert(checklist);
                }

                if (String.IsNullOrEmpty(feedback.FeedbackContent) == false)
                {
                    feedback.Audit = audit;
                    _unitOfWork.FeedbackRepository.Insert(feedback);
                }

                List<string> _currentUser = AuditFormHelper.GetAllLoggedInUser();
                foreach (var user in _currentUser)
                {
                    AuditorLog auditorLog = new AuditorLog
                    {
                        Audit = audit,
                        AuditorBadgeId = user,
                        DateAudit = audit.AuditDate
                    };

                    _unitOfWork.AuditorLogRepository.Insert(auditorLog);
                }

                _unitOfWork.Save();
            }
        }

        public bool IsAuditorAlreadySubmit(Audit audit)
        {
            List<string> _currentUser = AuditFormHelper.GetAllLoggedInUser();

            if(_currentUser.Count > 0)
            {
                // Check apakah auditor sudah melakukan audit
                var AllAudit = _unitOfWork.AuditorLogRepository.Get()
                    .Where(x => x.Audit.AuditDate == audit.AuditDate
                        && x.Audit.AuditCodeText == audit.AuditCodeText
                        && x.Audit.Location == audit.Location
                        && _currentUser.Contains(x.AuditorBadgeId)
                    ).Any();

                //Jika audit sudah melakukan submit sebelumnya
                if (AllAudit)
                    return false;
            }

            return true;
        }
    }
}
