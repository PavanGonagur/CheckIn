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
    public class UserHandler:IUserHandler
    {
        private readonly CheckInDb checkInDb;
        public UserHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public int AddUser(User user)
        {
            this.checkInDb.Users.Add(user);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.Users
                        orderby r.UserId descending
                        select r;
            if (query.Any())
            {
                return query.First().UserId;
            }
            return 0;
        }

        public User RetrieveUser(int userId)
        {
            var query = from r in this.checkInDb.Users
                        where r.UserId == userId
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

        public void UpdateUser(User user)
        {
            this.checkInDb.Users.AddOrUpdate(user);
            this.checkInDb.SaveChanges();
        }
    }
}
