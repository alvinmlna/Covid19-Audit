using Covid19_Audit.Viewmodel;
using Covid19_BusinessLogic.Helpers;
using Covid19_BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19_Audit.Controllers
{
    public class LoginController : Controller
    {
        private IUserServices userServices;

        public LoginController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        // GET: Login
        public ActionResult Index()
        {
            ViewBag.allUser = GetUserSelectList();
            ViewBag.Skills = new MultiSelectList(GetUserSelectList(), "Value", "Text");
            return View();
        }

        public ActionResult Admin()
        {
            LoginViewModel model = new LoginViewModel
            {
                PartnerNames = new string[] { "30132514" }
            };
            return View("Admin", model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (model.PartnerNames != null)
            {
                if (model.PartnerNames.Count() > 2)
                {
                    ModelState.AddModelError("PartnerNames", "Please select maximum 2 partner");
                }

                if (model.PartnerNames.Contains(model.Username))
                {
                    ModelState.AddModelError("PartnerNames", "Partner name cannot be same as username");
                }
            }


            if (model != null && ModelState.IsValid)
            {
                var result = userServices.Login(model.Username, model.PartnerNames);
                if (result)
                {
                    return RedirectToAction("Index", "AuditForm");
                }
                else
                {
                    ModelState.AddModelError("Username", "Badge Id Not Registered");
                }
            }

            ViewBag.Skills = new MultiSelectList(GetUserSelectList(), "Value", "Text");
            ViewBag.allUser = GetUserSelectList();
            return View("Index", model);
        }



        [HttpPost]
        public ActionResult LoginAdmin(LoginViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var result = userServices.LoginAdmin(model.Username, model.PartnerNames);
                if (result)
                {
                    return RedirectToAction("Index", "AuditForm");
                }
                else
                {
                    ModelState.AddModelError("Username", "Badge Id Not Registered");
                }
            }

            return View("Admin", model);
        }


        public ActionResult Logout()
        {
            AuditFormHelper.LogoutUser();

            ViewBag.allUser = GetUserSelectList();
            ViewBag.Skills = new MultiSelectList(GetUserSelectList(), "Value", "Text");
            return View("Index");
        }

        private IEnumerable<SelectListItem> GetUserSelectList()
        {
          return  userServices.GetUsers()
                .OrderBy(x => x.FullName)
                .Where(x => !x.FullName.Contains("Admin"))
                .Select(x => new SelectListItem
                {
                    Text = x.FullName,
                    Value = x.BadgeId
                });
        }

    }
}
