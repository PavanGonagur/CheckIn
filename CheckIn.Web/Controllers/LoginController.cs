using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Web.Business;
using CheckIn.Web.BusinessImpl;
using CheckIn.Web.Models;
using CheckIn.Web.Utilities;

namespace CheckIn.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminBusiness _adminBusiness;
        public LoginController()
        {
            _adminBusiness = new AdminBusiness();
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SessionUtility.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Login = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminModel model)
        {
            var admin = new AuthenticationUtility().AuthenticateUser(model.Password, model.Email);
            if (admin.AdminId != 0)
            {
                SessionUtility.CurrentAdmin = admin;
                return RedirectToAction("Index", "Home");
                //                return RedirectToAction("Index", new {id = id});
            }
            else
            {
                ViewBag.Login = "Authentication Failed";
                //return View();
            }
            return View();
        }

        public ActionResult LogOff()
        {
            SessionUtility.CurrentAdmin = null;
            return RedirectToAction("Index");
        }
    }
}