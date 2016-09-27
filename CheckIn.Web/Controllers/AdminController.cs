using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Web.Business;
using CheckIn.Web.BusinessImpl;
using CheckIn.Web.Models;
using CheckIn.Web.Models.Admin;
using CheckIn.Web.Utilities;

namespace CheckIn.Web.Controllers
{
    [AuthenticationFilter]
    public class AdminController : Controller
    {
        private readonly IAdminBusiness adminBusiness;

        private readonly IAuthenticationBusiness authenticationBusiness;

        public AdminController()
        {
            this.adminBusiness = new AdminBusiness();
            this.authenticationBusiness = new AuthenticationBusiness();
        }
 
        // GET: Admin
        public ActionResult Index()
        {
            var model = new AdminListModel().Fetch(SessionUtility.CurrentAdmin.AdminId);
            return View(model);
        }

        // GET: Admin/Details/5
        public ActionResult Channels(int id)
        {
            return PartialView("_AdminChannels", new AdminChannelModel());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return PartialView("_Create", new AdminModel());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(AdminModel model)
        {
            try
            {
                var errorMessage = model.Validate();
                if (errorMessage != null)
                {
                    ModelState.AddModelError("", errorMessage);
                }

                var id = adminBusiness.Save(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new AdminModel().ToModel(adminBusiness.RetrieveAdmin(id));
            return PartialView("_Create", model);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(AdminModel model)
        {
            try
            {
                var errorMessage = model.Validate();
                if (errorMessage != null)
                {
                    ModelState.AddModelError("", errorMessage);
                }

                var id = adminBusiness.Save(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
