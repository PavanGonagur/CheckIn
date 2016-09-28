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
    public class ChannelHandler: IChannelHandler
    {
        private readonly CheckInDb checkInDb;
        private const float AssignmentLength = (float).05;
        public ChannelHandler()
        {
            this.checkInDb = new CheckInDb();
        }

        public int AddChannel(Channel channel)
        {
            this.checkInDb.Channels.Add(channel);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.Channels
                        orderby r.ChannelId descending
                        select r;
            if (query.Any())
            {
                return query.First().ChannelId;
            }
            return 0;
        }

        public Channel RetrieveChannel(int channelId)
        {
            var query = this.checkInDb.Channels.Where(x => x.ChannelId == channelId);
            if (query.Any())
            {
                var currentChannel = query.FirstOrDefault();
                if (currentChannel != null)
                {
                    return currentChannel;
                }
            }
            return null;
        }

        public void UpdateChannel(Channel channel)
        {
            this.checkInDb.Channels.AddOrUpdate(channel);
            this.checkInDb.SaveChanges();
        }

        public List<Channel> RetrieveAllChannels()
        {
            var channels = this.checkInDb.Channels;
            return channels?.ToList();
        }

        public void DeleteChannel(Channel channel)
        {
            this.checkInDb.Channels.Remove(channel);
            this.checkInDb.SaveChanges();
        }

        public Channel RegisterToChannel(string otp)
        {
            var query = this.checkInDb.UserChannelMaps.Where(x => x.Otp == otp);
            if (query.Any())
            {
                var currentChannel = query.FirstOrDefault();
                if (currentChannel != null)
                {
                    return this.RetrieveChannel(currentChannel.ChannelId);
                }
            }
            return null;
        }

        public User RetrieveUserOnEmail(string email)
        {
            var query = from r in this.checkInDb.Users
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

        public List<Channel> RetrieveChannelsOnAdmin(int adminId)
        {
            var query = from ch in this.checkInDb.Channels
                        join ach in this.checkInDb.AdminChannelMaps
                        on ch.ChannelId equals ach.ChannelId
                        where ach.AdminId == adminId
                        select ch;
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }

        public List<Channel> RetrieveChannelsByLocationAndUser(float latitude, float longitude, int userId)
        {
            var channels = new List<Channel>();
            channels.Concat(this.GetPublicChannels(latitude, longitude));
            channels.Concat(this.GetPrivateChannelsForUserNotLocationBased(userId));
            channels.Concat(this.GetPrivateChannelsForUserLocationBased(userId, latitude, longitude));
            return channels;
        }

        private List<Channel> GetPublicChannels(float latitude, float longitude)
        {
            var query = from channel in this.checkInDb.Channels
                        where channel.IsPublic && 
                            ((channel.Latitude >= (latitude - AssignmentLength))
                                && (channel.Longitude >= (longitude - AssignmentLength))
                                && (channel.Latitude <= (latitude + AssignmentLength))
                                && (channel.Longitude <= (longitude + AssignmentLength)))
                        select channel;

            if (query.Any())
            {
                var channels = query.ToList();
                return channels;
            }
            return new List<Channel>();
        }

        private List<Channel> GetPrivateChannelsForUserNotLocationBased(int userId)
        {
            var query = from uc in this.checkInDb.UserChannelMaps
                        join ch in this.checkInDb.Channels on uc.ChannelId equals ch.ChannelId
                        where
                            uc.UserId == userId &&
                            !ch.IsLocationBased &&
                            !ch.IsPublic
                        select ch;

            if (query.Any())
            {
                var channels = query.ToList();
                return channels;
            }
            return new List<Channel>();
        }

        private List<Channel> GetPrivateChannelsForUserLocationBased(int userId, float latitude, float longitude)
        {
            var query = from uc in this.checkInDb.UserChannelMaps
                        join ch in this.checkInDb.Channels on uc.ChannelId equals ch.ChannelId
                        where
                            uc.UserId == userId &&
                            ch.IsLocationBased &&
                            !ch.IsPublic &&
                            ((ch.Latitude >= (latitude - AssignmentLength))
                                && (ch.Longitude >= (longitude - AssignmentLength))
                                && (ch.Latitude <= (latitude + AssignmentLength))
                                && (ch.Longitude <= (longitude + AssignmentLength)))
                        select ch;

            if (query.Any())
            {
                var channels = query.ToList();
                return channels;
            }
            return new List<Channel>();
        }

        public Channel GetChannelOnText(string searchText)
        {
            var query = from ch in this.checkInDb.Channels
                        where ch.Name.ToLower() == searchText.ToLower() select ch;
            if (query.Any())
            {
                return query.FirstOrDefault();
            }
            return null;
        }
    }
}
