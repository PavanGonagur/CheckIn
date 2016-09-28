using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Data;
using CheckIn.Web.Models;
using CheckIn.Web.Models.Channel;
using CheckIn.Web.Models.Channel.Application;
using CheckIn.Web.Models.Channel.Contact;
using CheckIn.Web.Models.Channel.Location;
using CheckIn.Web.Models.Channel.Profile;
using CheckIn.Web.Models.Channel.WebClip;
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

        #region Users

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

        #endregion

        #region Applications

        // GET: Admin/Details/5
        public ActionResult Applications(int id)
        {
            return View(new ChannelApplicationListModel(id));
        }

        // GET: Admin/Details/5
        public ActionResult AddApplications(int id)
        {
            return PartialView("_ChannelApplications", new ApplicationEditModel {ChannelId = id});
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult AddApplications(ApplicationEditModel model)
        {
            try
            {
                //TODO Add Users To Channel
                //model.AddedUsers = model.UserEmailIds.Split(',').Select(x => new ChannelUser { Email = x.Trim() }).Where(x => !string.IsNullOrEmpty(x.Email)).ToList();
                return RedirectToAction("Applications", new { id = model.ChannelId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Channel/Delete/5
        public ActionResult DeleteApplication(int id)
        {
            return View();
        }

        #endregion

        #region WebClips

        // GET: Admin/Details/5
        public ActionResult WebClips(int id)
        {
            return View(new ChannelWebClipListModel(id));
        }

        // GET: Admin/Details/5
        public ActionResult AddWebClips(int id)
        {
            return PartialView("_ChannelWebClips", new WebClipEditModel {ChannelId = id});
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult AddWebClips(WebClipEditModel model)
        {
            try
            {
                //TODO Add Users To Channel
                //model.AddedUsers = model.UserEmailIds.Split(',').Select(x => new ChannelUser { Email = x.Trim() }).Where(x => !string.IsNullOrEmpty(x.Email)).ToList();
                return RedirectToAction("WebClips", new { id = model.ChannelId });
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Locations

        // GET: Admin/Details/5
        public ActionResult Locations(int id)
        {
            return View(new ChannelLocationListModel(id));
        }

        // GET: Admin/Details/5
        public ActionResult AddLocations(int id)
        {
            return PartialView("_ChannelLocations", new LocationEditModel() {ChannelId = id});
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult AddLocations(LocationEditModel model)
        {
            try
            {
                //TODO Add Users To Channel
                //model.AddedUsers = model.UserEmailIds.Split(',').Select(x => new ChannelUser { Email = x.Trim() }).Where(x => !string.IsNullOrEmpty(x.Email)).ToList();
                return RedirectToAction("Locations", new { id = model.ChannelId });
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Contacts

        // GET: Admin/Details/5
        public ActionResult Contacts(int id)
        {
            return View(new ChannelContactListModel(id));
        }

        // GET: Admin/Details/5
        public ActionResult AddContacts(int id)
        {
            return PartialView("_ChannelContacts", new ContactEditModel { ChannelId = id });
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult AddContacts(ContactEditModel model)
        {
            try
            {
                //TODO Add Users To Channel
                //model.AddedUsers = model.UserEmailIds.Split(',').Select(x => new ChannelUser { Email = x.Trim() }).Where(x => !string.IsNullOrEmpty(x.Email)).ToList();
                return RedirectToAction("Contacts", new { id = model.ChannelId });
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Profiles
        /*// GET: Admin/Details/5
        public ActionResult Profiles(int id)
        {
            return PartialView("_ChannelProfiles", new ProfileViewModel().Initialize(id));
        }*/

        // GET: Admin/Details/5
        public ActionResult AddProfile(int id, ProfileType profileType)
        {
            return PartialView("_EditProfile", new WifiProfileModel(id, profileType));
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult AddProfile(BaseProfileModel model)
        {
            try
            {
                //TODO Add Users To Channel
                //model.AddedUsers = model.UserEmailIds.Split(',').Select(x => new ChannelUser { Email = x.Trim() }).Where(x => !string.IsNullOrEmpty(x.Email)).ToList();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

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
