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
    using CheckIn.Handler.CustomEntities;
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

        public User RetrieveUserOnEmailUserName(string emailUserName)
        {
            var query = this.checkInDb.Users.Where(x => x.EmailUserName.Equals(emailUserName));
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

        public List<CustomUserEntity> RetrieveUsersByChannel(int channelId)
        {
            var query = from u in this.checkInDb.Users
                        join uc in this.checkInDb.UserChannelMaps
                        on u.UserId equals uc.UserId
                        where uc.ChannelId == channelId
                        select new CustomUserEntity()
                                   {
                                       EmailUserName = u.EmailUserName,
                                       Email = uc.EmailId,
                                       PhoneNumber = u.PhoneNumber,
                                       FirstName = u.FirstName,
                                       LastName = u.LastName,
                                       Name = u.Name,
                                       Status = uc.Otp == null
                                   };
            var tempUsers = from uc in this.checkInDb.UserEmailChannels
                            where uc.ChannelId == channelId
                            select new CustomUserEntity()
                            {
                                Email = uc.Email,
                                Status = false
                            };
            if (query.Any())
            {
                if (tempUsers.Any())
                {
                    var users = query.ToList();
                    users.AddRange(tempUsers.ToList());
                    return users;
                }
                return query.OrderBy(x => x.Email).ToList();
            }
            else if (tempUsers.Any())
            {
                return tempUsers.OrderBy(x => x.Email).ToList();
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
