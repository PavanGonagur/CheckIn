using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Web.BusinessImpl;

namespace CheckIn.Web.Models.Admin
{
    using CheckIn.Data.Entities;

    public class AdminListModel
    {
        public AdminListModel()
        {
            Admins = new List<AdminModel>();
        }
        public List<AdminModel> Admins { get; set; }

        public AdminListModel Fetch(int id, string searchText = "")
        {
            var admins = new AdminBusiness().RetrieveAllAdmins() ?? new List<Admin>();
            foreach (var admin in admins)
            {
                Admins.Add(new AdminModel
                {
                    AdminId = admin.AdminId,
                    Email = admin.Email,
                    Name = admin.Name,
                    PhoneNumber = admin.PhoneNumber,
                    Channels = admin.AdminChannelMaps.Count,
                    IsSuperAdmin = admin.IsSuperAdmin,
                });
            }
            return this;
        }
    }
}