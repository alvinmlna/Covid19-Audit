using Covid19_Audit.Class;
using Covid19_Audit.Security;
using Covid19_Audit.Viewmodel;
using Covid19_Audit.Viewmodel.Report;
using Covid19_BusinessLogic.Class.Report;
using Covid19_BusinessLogic.Services.Interfaces;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace Covid19_Audit.Controllers
{
    [SessionAuthorize]
    public class FeedbackReportController : Controller
    {
        private readonly IAuditReportingService reportingService;
        private readonly IUserServices userServices;
        IEnumerable<User> GMDS;


        public FeedbackReportController(IAuditReportingService reportingService, IUserServices userServices)
        {
            this.reportingService = reportingService;
            this.userServices = userServices;

            GMDS = userServices.GetUsers();
        }

        // GET: ChecklistReport
        public ActionResult Index()
        {
            Session["DateReport2"] = null;
            return View();
        }

        public ActionResult ShowReport(AuditReportViewModel model)
        {
            Session["DateReport2"] = model;
            return PartialView("FeedbackGrid", model);
        }

        [HttpPost]
        public ActionResult LoadData()
        {
            if (Session["DateReport2"] is AuditReportViewModel model)
            {
                try
                {
                    var draw = Request.Form.GetValues("draw").FirstOrDefault();
                    var start = Request.Form.GetValues("start").FirstOrDefault();
                    var length = Request.Form.GetValues("length").FirstOrDefault();
                    var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                    var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                    var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                    //Paging Size (10,20,50,100)    
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;
                    int skip = start != null ? Convert.ToInt32(start) : 0;
                    int recordsTotal = 0;

                    // Getting all Catalog data    
                    IEnumerable<AuditFeedbackReportViewModel> result = reportingService.GetAuditFeedbackReportsByDate(model.From, model.To).Select(x => new AuditFeedbackReportViewModel
                    {
                        TransactionId = x.AuditId,
                        AuditDate = x.Audit.AuditDate,
                        Auditor = GMDS.FirstOrDefault(z => z.BadgeId == x.Audit.Auditor)?.FullName,
                        AuditorPartner1 = GMDS.FirstOrDefault(z => z.BadgeId == x.Audit.AuditorPartner1)?.FullName,
                        AuditorPartner2 = GMDS.FirstOrDefault(z => z.BadgeId == x.Audit.AuditorPartner2)?.FullName,
                        Location = x.Audit.Location,
                        AuditCode = x.Audit.AuditCodeText,
                        FocusArea = x.FocusArea,
                        FeedbackContent = x.FeedbackContent,
                        Category = x.Category,
                        UploadedPicture = ExportHelper.ImageBuilder(x.UploadedFile),
                    }).OrderByDescending(x => x.AuditDate);

                    //Sorting    
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                    {
                        result = result.OrderBy(sortColumn + " " + sortColumnDir);
                    }
                    //Search    
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        result = result.Where(m => m.AuditCode.Contains(searchValue));
                    }

                    //total number of rows count     
                    recordsTotal = result.Count();
                    //Paging     
                    var data = result.Skip(skip).Take(pageSize).ToList();

                    //Returning Json Data    
                    return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return Json(new { draw = 1, recordsFiltered = 0, recordsTotal = 0, data = 0 });
        }
        public void ExportFeedback()
        {
            var model = Session["DateReport2"] as AuditReportViewModel;

            // Getting all Catalog data    
            IEnumerable<dynamic> result = reportingService.GetAuditFeedbackReportsByDate(model.From, model.To).Select(x => new
            {
                x.Audit.AuditDate,
                Auditor = GMDS.FirstOrDefault(z => z.BadgeId == x.Audit.Auditor)?.FullName,
                AuditorPartner1 = GMDS.FirstOrDefault(z => z.BadgeId == x.Audit.AuditorPartner1)?.FullName,
                AuditorPartner2 = GMDS.FirstOrDefault(z => z.BadgeId == x.Audit.AuditorPartner2)?.FullName,
                Location = x.Audit.Location,
                AuditCode = x.Audit.AuditCodeText,
                FocusArea = x.FocusArea,
                x.FeedbackContent,
                Category = x.Category,
                SubmittedDate = x.Audit.SubmittedDate,
            }).OrderByDescending(x => x.AuditDate);


            //Export function
            ExportHelper.Export(result, model);
        }


    }
}