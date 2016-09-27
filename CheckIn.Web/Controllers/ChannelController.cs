using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Web.Models;
using CheckIn.Web.Models.Channel;
using CheckIn.Web.Utilities;

namespace CheckIn.Web.Controllers
{
    public class ChannelController : Controller
    {
        // GET: Channel
        public ActionResult Index()
        {
            var model = new ChannelListModel().Fetch(SessionUtility.CurrentAdmin.AdminId);
            return View(model);
        }

        // GET: Admin/Details/5
        public ActionResult Users(int id)
        {
            return View(new ChannelUserModel(id));
        }

        // GET: Admin/Details/5
        public ActionResult AddUsers(int id)
        {
            return PartialView("_ChannelUsers", new ChannelUserModel(id));
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult AddUsers(ChannelUserModel model)
        {
            try
            {
                //TODO Add Users To Channel
                model.AddedUsers = model.UserEmailIds.Split(',').Select(x => new ChannelUser { Email = x.Trim()}).Where(x => !string.IsNullOrEmpty(x.Email)).ToList();
                return RedirectToAction("Users", new {id = model.ChannelId});
            }
            catch
            {
                return View();
            }
        }

        // GET: Channel/Create
        public ActionResult Create()
        {
            return PartialView("_Create", new ChannelViewModel());
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult Create(ChannelViewModel model)
        {
            try
            {
                // TODO: Add new channel

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Channel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Channel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Channel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Channel/Delete/5
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
