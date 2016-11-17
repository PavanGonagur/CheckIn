using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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

        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            if (SessionUtility.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Login = "";
            return View();
        }

        [System.Web.Mvc.HttpPost]
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

        [System.Web.Mvc.HttpPost]
        public ActionResult ForgetPassword(string email)
        {
            //TODO: Validate Email not empty
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Email field should not be empty");
                return View();
            }
            //TODO: Search Admin, Generate Password, Save it, Make PasswordResetNeeded true
            var admin = this._adminBusiness.RetrieveAdminOnEmail(email);
            if (admin == null)
            {
                ModelState.AddModelError("", "Admin with given email not found");
                return View();
            }
            var pass = AutoGeneratePasswordUtility.GeneratePassword();
            admin.Password = pass;
            admin.PasswordResetNeeded = true;
            this._adminBusiness.UpdateAdmin(admin);
            return RedirectToAction("Index");
        }

        public ActionResult LogOff()
        {
            SessionUtility.CurrentAdmin = null;
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Reset()
        {
            if (SessionUtility.IsAuthenticated && !SessionUtility.CurrentAdmin.PasswordResetNeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Reset(PasswordResetModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match");
                return View();
            }
            //TODO: Validate Old Password is correct
            if (SessionUtility.CurrentAdmin.Password != HashUtility.GetHash(model.OldPassword))
            {
                ModelState.AddModelError("", "Old Password does not match");
                return View();
            }
            if (model.Password == model.OldPassword)
            {
                ModelState.AddModelError("", "Cannot use the previous password");
                return View();
            }
            //TODO: Reset Password and change PasswordResetNeeded
            //var admin = new AuthenticationUtility().AuthenticateUser(model.Password, model.Email);
            var admin = this._adminBusiness.RetrieveAdmin(SessionUtility.CurrentAdmin.AdminId);
            if (admin != null)
            {
                admin.Password = HashUtility.GetHash(model.Password);
                admin.PasswordResetNeeded = false;
                this._adminBusiness.UpdateAdmin(admin);
            }
            
                SessionUtility.CurrentAdmin.PasswordResetNeeded = false;
                return RedirectToAction("Index", "Channel");
             
            //else
            //{
            //    ModelState.AddModelError("", "Could not reset password");
            //    //return View();
            //}
            //return View("Reset");
        }
    }
}