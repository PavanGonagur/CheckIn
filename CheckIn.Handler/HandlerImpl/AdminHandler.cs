using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using System.Data.Entity.Migrations;

    using CheckIn.Data;
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    public class AdminHandler: IAdminHandler
    {
        private readonly CheckInDb checkInDb;
        public AdminHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public int AddAdmin(Admin admin)
        {
            this.checkInDb.Admins.Add(admin);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.Admins
                        orderby r.AdminId descending
                        select r;
            if (query.Any())
            {
                return query.First().AdminId;
            }
            return 0;
        }

        public void UpdateAdmin(Admin admin)
        {
            this.checkInDb.Admins.AddOrUpdate(admin);
            this.checkInDb.SaveChanges();
        }

        public Admin RetrieveAdmin(int adminId)
        {
            var query = this.checkInDb.Admins.Where(x => x.AdminId == adminId);
            if (query.Any())
            {
                var currentUser = query.FirstOrDefault();
                if (currentUser != null)
                {
                    return currentUser;
                }
            }
            return null;
        }

        public Admin RetrieveAdminOnEmail(string email)
        {
            var query = from r in this.checkInDb.Admins
                        where r.Email == email
                        select r;
            if (query.Any())
            {
                var currentUser = query.FirstOrDefault();
                if (currentUser != null)
                {
                    return currentUser;
                }
            }
            return null;
        }

        public List<Admin> RetrieveAllAdmins()
        {
            var users = this.checkInDb.Admins;
            if (users != null)
            {
                return users.ToList();
            }
            return null;
        }

        public void DeleteAdmin(Admin admin)
        {
            this.checkInDb.Admins.Remove(admin);
            this.checkInDb.SaveChanges();
        }
    }
}
