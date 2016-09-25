using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Web.BusinessImpl;

namespace CheckIn.Web.Models.Admin
{
    public class AdminListModel
    {
        public AdminListModel()
        {
            Admins = new List<AdminModel>();
        }
        public List<AdminModel> Admins { get; set; }

        public AdminListModel Fetch(int id, string searchText = "")
        {
            var admins = new List<Data.Entities.Admin> {new AdminBusiness().RetrieveAdminDummy(1)};
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