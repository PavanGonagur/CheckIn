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

        public int CheckUserExists(string email)
        {
            var query = this.checkInDb.Users.Where(x => x.Email.Equals(email));
            if (query.Any())
            {
                return query.First().UserId;
            }
            return 0;
        }

        public User RetrieveUser(int userId)
        {
            var query = this.checkInDb.Users.Where(x => x.UserId == userId);
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

        public List<User> RetrieveAllUsers()
        {
            var users = this.checkInDb.Users;
            if (users != null)
            {
                return users.ToList();
            }
            return null;
        }

        public User RetrieveUserOnEmail(string emailId)
        {
            var query = this.checkInDb.Users.Where(x => x.Email.Equals(emailId));
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

        public void DeleteUser(User user)
        {
            this.checkInDb.Users.Remove(user);
            this.checkInDb.SaveChanges();
        }
    }
}
