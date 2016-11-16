using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Web.Business;
using CheckIn.Web.BusinessImpl;
using CheckIn.Web.Models;
using CheckIn.Web.Models.Login;
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
        public ActionResult Index(LoginModel model)
        {
            var admin = new AuthenticationUtility().AuthenticateUser(model.Password, model.Email);
            if (admin.AdminId != 0)
            {
                SessionUtility.CurrentAdmin = admin;
                if (admin.PasswordResetNeeded)
                {
                    return RedirectToAction("Reset");
                }
                return RedirectToAction("Index", "Channel");
                //                return RedirectToAction("Index", new {id = id});
            }
            else
            {
                ViewBag.Login = "Authentication Failed";
                //return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(/*string email*/)
        {
            //TODO: Validate Email not empty
            //TODO: Search Admin, Generate Password, Save it, Make PasswordResetNeeded true
            return RedirectToAction("Index");
        }

        public ActionResult LogOff()
        {
            SessionUtility.CurrentAdmin = null;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Reset()
        {
            if (SessionUtility.IsAuthenticated && !SessionUtility.CurrentAdmin.PasswordResetNeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Reset(PasswordResetModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match");
                return View();
            }
            //TODO: Validate Old Password is correct
            if (model.Password == model.OldPassword)
            {
                ModelState.AddModelError("", "Cannot use the previous password");
                return View();
            }
            //TODO: Reset Password and change PasswordResetNeeded
            //var admin = new AuthenticationUtility().AuthenticateUser(model.Password, model.Email);
            if (true) //Password successfully reset //TODO: Add Proper Condition
            {
                SessionUtility.CurrentAdmin.PasswordResetNeeded = false;
                return RedirectToAction("Index", "Channel");
                //                return RedirectToAction("Index", new {id = id});
            }
            else
            {
                ModelState.AddModelError("", "Could not reset password");
                //return View();
            }
            return View("Reset");
        }
    }
}