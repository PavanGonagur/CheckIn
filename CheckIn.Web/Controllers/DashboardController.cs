using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Web.Models.Dashboard;

namespace CheckIn.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View(new RulesModel());
        }

        [HttpPost]
        public ActionResult Index(RulesModel model)
        {
            try
            {
                // TODO: Add new channel
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}