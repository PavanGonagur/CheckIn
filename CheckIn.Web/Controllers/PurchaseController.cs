using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Web.Business;
using CheckIn.Web.BusinessImpl;
using CheckIn.Web.Models.Purchase;

namespace CheckIn.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseChannelBusiness purchaseChannelBusiness;
        public PurchaseController()
        {
            this.purchaseChannelBusiness = new PurchaseChannelBusiness();
        }
        // GET: Purchase
        public ActionResult Index()
        {
            return View(new PurchaseChannelModel());
        }

        [HttpPost]
        public ActionResult Index(PurchaseChannelModel model)
        {
            this.purchaseChannelBusiness.AutoProvisionAdminChannel(model);
            return RedirectToAction("Index", "Login");
        }
    }
}