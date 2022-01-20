using Covid19_Audit.Security;
using Covid19_Audit.Viewmodel;
using Covid19_Audit.Viewmodel.Audit_Form;
using Covid19_Audit_EntityFramework;
using Covid19_Audit_EntityFramework.Repository;
using Covid19_Audit_EntityFramework.Repository.Interface;
using Covid19_BusinessLogic.Helpers;
using Covid19_BusinessLogic.Services.Interfaces;
using Covid19_Dependency_Injection;
using EntityFramework;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Covid19_Audit.Controllers
{
    [SessionAuthorize]
    public class AuditFormController : Controller
    {
        private  IAuditFormServices auditFormServices;

        public AuditFormController(IAuditFormServices auditFormServices)
        {
            this.auditFormServices = auditFormServices;
        }

        // GET: AuditForm
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowAuditItem(AuditViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Audit audit = new Audit {
                    AuditDate = model.AuditDate,
                    AuditCodeText = model.AuditCode,
                    Location = model.Location,
                };

                var isAvailableForAudit = auditFormServices.IsAuditorAlreadySubmit(audit);
                if (isAvailableForAudit == false)
                {
                    ViewBag.validation = "Audit result has been submitted for the following info:<br/>Date: " + audit.AuditDate.ToLongDateString() + "<br/>Location: " + audit.Location + "<br/>Audit Code: " + audit.AuditCodeText;
                    ModelState.AddModelError("CustomError", "");
                    return View("Index", model);
                }

                var db = auditFormServices.GetAuditCheckListByCode(model.AuditCode);

                var checklist = db.FocusAreas.Select(x => new AuditCheckListViewModel
                {
                    ItemTitle = x.AreaName,
                    ItemId = x.FocusAreaId,
                    AuditItems = x.Questions.Select(z => new AuditItemViewModel
                    {
                        QuestionText = z.QuestionText,
                        QuestionId = z.QuestionId,
                        Category = z.Category
                    }).ToList()
                }).OrderByDescending(x => x.ItemTitle == "General").ToList();



                var auditForm = new AuditFormViewModel
                {
                    AuditCheckList = checklist,
                    AuditCode = model.AuditCode,
                    AuditDate = model.AuditDate,
                    Location = model.Location
                };

                return View("AuditItems", auditForm);
            }

            return View("Index", model);
        }

        public ActionResult SubmitAudit(AuditFormViewModel model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {

                    Audit audit = new Audit
                    {
                        AuditDate = model.AuditDate,
                        AuditCodeText = model.AuditCode,
                        Location = model.Location,
                        SubmittedDate = DateTime.Now
                    };

                    List<CheckLists> checkLists = new List<CheckLists>();
                    foreach (var c in model.AuditCheckList)
                    {
                        foreach (var item in c.AuditItems)
                        {

                            List<string> uploadedFile = new List<string>();

                            foreach (var _file in item.PostedFiles)
                            {
                                if (_file != null)
                                {
                                    var fileName = (string)Path.GetRandomFileName() + "-" + (string)Path.GetFileName(_file.FileName);


                                    var nowDate = String.Format("{0:dd-MM-yyyy}", DateTime.Now);
                                    var target = "~/Data/Files/" + nowDate + "/";

                                    Directory.CreateDirectory(Server.MapPath(target));

                                    _file.SaveAs(Server.MapPath(target + fileName));

                                    //save to list
                                    uploadedFile.Add(target + fileName);
                                }
                            }

                            CheckLists checkList = new CheckLists
                            {
                                FocusAreaText = c.ItemTitle,
                                QuestionText = item.QuestionText,
                                Category = item.Category,
                                Result = item.Result ?? false,
                                Remark = item.Remark,
                                UploadedFile = String.Join(",", uploadedFile)
                            };
                            checkLists.Add(checkList);
                        }
                    }

                    string feedbackItem = model.FeedbackCheckList.FeedbackItem?.Trim();
                    Feedback feedback = new Feedback();

                    if (String.IsNullOrEmpty(feedbackItem) == false)
                    {
                        List<string> uploadedFile = new List<string>();

                        foreach (var _file in model.FeedbackCheckList.PostedFiles)
                        {

                            if (_file != null)
                            {
                                var fileName = (string)Path.GetRandomFileName() + "-" + (string)Path.GetFileName(_file.FileName);


                                var nowDate = String.Format("{0:dd-MM-yyyy}", DateTime.Now);
                                var target = "~/Data/Files/" + nowDate + "/";

                                Directory.CreateDirectory(Server.MapPath(target));

                                _file.SaveAs(Server.MapPath(target + fileName));

                                //save to list
                                uploadedFile.Add(target + fileName);
                            }
                        }

                        feedback.Category = model.FeedbackCheckList.Category;
                        feedback.FeedbackContent = feedbackItem;
                        feedback.FocusArea = model.FeedbackCheckList.Area;
                        feedback.UploadedFile = String.Join(",", uploadedFile);
                    }

                    auditFormServices.SubmitAudit(audit, checkLists, feedback);

                    ViewBag.result = "Record Inserted Successfully!";
                    return View("index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.result = ex.Message;
                return View("index");
            }

            return View("AuditItems", model);
        }
    }
}