using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Data;
using CheckIn.Web.Business;
using CheckIn.Web.BusinessImpl;
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
    [AuthenticationFilter]
    public class ChannelController : Controller
    {
        private readonly IUserBusiness userBusiness;

        private readonly IUserChannelMapBusiness userChannelMapBusiness;

        private readonly IChannelBusiness channelBusiness;

        private readonly IApplicationBusiness applicationBusiness;

        private readonly IWebClipBusiness webClipBusiness;

        private readonly IContactBusiness contactBusiness;

        private readonly IProfileBusiness profileBusiness;

        private readonly ILocationBusiness locationBusiness;

        private readonly IChatBusiness chatBusiness;



        public ChannelController()
        {
            this.userBusiness = new UserBusiness();
            this.userChannelMapBusiness = new UserChannelMapBusiness();
            this.channelBusiness = new ChannelBusiness();
            this.applicationBusiness = new ApplicationBusiness();
            this.chatBusiness = new ChatBusiness();
            this.contactBusiness = new ContactBusiness();
            this.profileBusiness = new ProfileBusiness();
            this.webClipBusiness = new WebClipBusiness();
            this.locationBusiness = new LocationBusiness();
        }

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
            var model = new ChannelUserModel(id)
            {
                AddedUsers = userBusiness.RetrieveUsersByChannel(id)
            };
            return View(model);
        }

        // GET: Admin/Details/5
        public ActionResult AddUsers(int id)
        {
            var model = new ChannelUserModel(id)
            {
                AddedUsers = userBusiness.RetrieveUsersByChannel(id)
            };
            return PartialView("_ChannelUsers", model);
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult AddUsers(ChannelUserModel model)
        {
            try
            {
                //TODO Add Users To Channel
                model.AddedUsers = model.UserEmailIds.Split(',').Select(x => new ChannelUser { Email = x.Trim()}).Where(x => !string.IsNullOrEmpty(x.Email)).ToList();
                userChannelMapBusiness.AddUserChannelMap(new UserChannelMapModel {ChannelId = model.ChannelId, Emails = model.AddedUsers.Select(x => x.Email).ToList()});
                return RedirectToAction("Users", new {id = model.ChannelId});
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteUser(string email)
        {
            return RedirectToAction("Users");
        }

        #endregion

        #region Applications

        // GET: Admin/Details/5
        public ActionResult Applications(int id)
        {
            var model = new ChannelApplicationListModel(id)
            {
                Applications = applicationBusiness.RetrieveApplicationsByChannelId(id) ?? new List<ApplicationModel>()
            };
            return View(model);
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
                applicationBusiness.AddApplication(model.ToEntity());
                return RedirectToAction("Applications", new { id = model.ChannelId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Channel/Delete/5
        [HttpGet]
        public ActionResult DeleteApplication(int id)
        {
            return PartialView("_DeleteConfirmation", new DeleteModel {Id = id});
        }

        // GET: Channel/Delete/5
        [HttpPost]
        public ActionResult DeleteApplication(DeleteModel model)
        {
            var application = applicationBusiness.RetrieveApplicationById(model.Id);
            applicationBusiness.DeleteApplication(application);
            return RedirectToAction("Applications", new { id = application.ChannelId });
        }

        #endregion

        #region WebClips

        // GET: Admin/Details/5
        public ActionResult WebClips(int id)
        {
            var model = new ChannelWebClipListModel(id)
            {
                WebClips = webClipBusiness.RetrieveWebClipsByChannelId(id) ?? new List<WebClipModel>()
            };
            return View(model);
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
                webClipBusiness.AddWebClip(model.ToEntity());
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
            var model = new ChannelLocationListModel(id)
            {
                Locations = locationBusiness.RetrieveLocationsByChannelId(id) ?? new List<LocationModel>()
            };
            return View(model);
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
                locationBusiness.AddLocation(model.ToEntity());
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
            var model = new ChannelContactListModel(id)
            {
                Contacts = contactBusiness.RetrieveContactsByChannelId(id) ?? new List<ContactModel>()
            };
            return View(model);
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
                contactBusiness.AddContact(model.ToEntity());
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
            return PartialView("_EditProfile", profileBusiness.BuildProfileModel(id, profileType));
        }

        // POST: Channel/Create
        [HttpPost]
        public ActionResult AddProfile(BaseProfileModel model)
        {
            try
            {
                //TODO Add Users To Channel
                if (model.ProfileType == ProfileType.WiFi)
                {
                    profileBusiness.AddProfile(model.ToEntity());
                }
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
                channelBusiness.AddChannel(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Channel/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                // TODO: Add new channel
                var model = channelBusiness.GetChannel(id);
                return PartialView("_Create", model);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // POST: Channel/Edit/5
        [HttpPost]
        public ActionResult Edit(ChannelViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                channelBusiness.AddChannel(model);
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
