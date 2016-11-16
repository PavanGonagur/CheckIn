using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Web.Models.Purchase;

namespace CheckIn.Web.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View(new PurchaseChannelModel());
        }

        [HttpPost]
        public ActionResult Index(PurchaseChannelModel model)
        {
            return RedirectToAction("Index", "Login");
        }
    }
}