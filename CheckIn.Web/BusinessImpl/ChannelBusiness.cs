using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using CheckIn.Web.Common;
using CheckIn.Web.Utilities;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Models.Channel;

    using Microsoft.Ajax.Utilities;

    using ChannelModel = CheckIn.Web.Models.ChannelModel;

    public class ChannelBusiness : IChannelBusiness
    {
        private IChannelHandler channelHandler;

        private IUserChannelMapHandler userChannelMapHandler;

        private IAdminChannelMapHandler adminChannelMapHandler;

        private IProfileHandler profileHandler;

        private IApplicationHandler applicationHandler;

        private ILocationHandler locationHandler;

        private IContactHandler contactHandler;

        private IWebClipHandler webClipHandler;

        private IChatHandler chatHandler;

        private IUserEmailChannelHandler userEmailChannelHandler;

        public ChannelBusiness()
        {
            this.channelHandler = new ChannelHandler();
            this.adminChannelMapHandler = new AdminChannelMapHandler();
            this.userChannelMapHandler = new UserChannelMapHandler();
            this.profileHandler = new ProfileHandler();
            this.applicationHandler = new ApplicationHandler();
            this.locationHandler = new LocationHandler();
            this.contactHandler = new ContactHandler();
            this.webClipHandler = new WebClipHandler();
            this.chatHandler = new ChatHandler();
            this.userEmailChannelHandler = new UserEmailChannelHandler();
        }
        public int AddChannel(ChannelViewModel channelModel)
        {
            var channel = new Channel()
                              {
                                  IsLocationBased = channelModel.IsLocationBased,
                                  IsPublic = channelModel.IsPublic,
                                  Name = channelModel.Name,
                                  ChannelId = channelModel.ChannelId,
                                  Description = channelModel.Description,
                                  Latitude = channelModel.Latitude,
                                  Longitude = channelModel.Longitude,
                                  TimeOfActivation = channelModel.TimeOfActivation.ToString("dd-MM-yyyy HH:mm:ss"),
                                  TimeOfDeactivation = channelModel.TimeOfDeactivation.ToString("dd-MM-yyyy HH:mm:ss"),
                              };
            if (channel.ChannelId == 0)
            {
                channel.ChatRooms = new List<ChatRoom>
                {
                    new ChatRoom
                    {
                        Name = channel.Name + "Chat Room",
                        ChatMessage = new List<ChatMessage>
                        {
                            new ChatMessage
                            {
                                IsAdminMessage = true,
                                Message = "Welcome to " + channel.Name,
                                IsImage = false,
                                TimeOfGeneration = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                            }
                        }
                    }
                };
                channel.Branding = new List<ChannelBranding> {
                    new ChannelBranding
                    {
                        IconUrl = Constants.ServerUrl + "/icons/default.png",
                        PrimaryColor = "#237869",
                        SecondaryColor = "#34A68D",
                        TertiaryColor = "#FFFFFF"
                    }
                };
                return this.channelHandler.AddChannel(channel);
            }
            this.channelHandler.UpdateChannel(channel);
            return channel.ChannelId;
        }

        public Channel RetrieveChannelById(int channelId)
        {
            return this.channelHandler.RetrieveChannel(channelId);
        }

        public void DeleteChannel(Channel channel)
        {
            var apps = this.applicationHandler.RetrieveApplicationsByChannelId(channel.ChannelId);
            if (apps != null)
            {
                apps.ForEach(
                x =>
                {
                    this.applicationHandler.DeleteApplication(x);
                });
            }
            
            var webs = this.webClipHandler.RetrieveWebClipsByChannelId(channel.ChannelId);
            if (webs != null)
            {
                webs.ForEach(
                x =>
                {
                    this.webClipHandler.DeleteWebClip(x);
                });
            }
            
            var conts = this.contactHandler.RetrieveContactsByChannelId(channel.ChannelId);
            if (conts != null)
            {
                conts.ForEach(
                x =>
                {
                    this.contactHandler.DeleteContact(x);
                });
            }
            
            var locs = this.locationHandler.RetrieveLocationsByChannelId(channel.ChannelId);
            if (locs != null)
            {
                locs.ForEach(x => this.locationHandler.DeleteLocation(x));
            }
            
            var chatMessages = this.chatHandler.RetrieveChatMessagesByChannelId(channel.ChannelId);
            if (chatMessages != null)
            {
                chatMessages.ForEach(
                x =>
                {
                    this.chatHandler.DeleteChatMessage(x);
                });
            }
            var chatRoom = this.chatHandler.RetrieveChatRoomByChannelId(channel.ChannelId);
            if(chatRoom != null)
           this.chatHandler.DeleteChatRoom(chatRoom);
            
            //var profileKeyValues = this.profileHandler.
            var profiles = this.profileHandler.RetrieveProfilesByChannelId(channel.ChannelId);
            if (profiles != null)
            {

                profiles.ForEach(
                    x =>
                        {
                            var profileKeyValues = this.profileHandler.RetrieveProfileKeyValuesByProfileId(x.ProfileId);
                            profileKeyValues.ForEach(y => this.profileHandler.DeleteProfileKeyValue(y));
                            this.profileHandler.DeleteProfile(x);
                        });

            }
            
            channel.UserChannelMaps.ForEach(x => this.userChannelMapHandler.DeleteUserChannelMap(x));
            channel.AdminChannelMaps.ForEach(x => this.adminChannelMapHandler.DeleteAdminChannelMap(x));
            var userEmailChannelMaps = this.userEmailChannelHandler.RetrieveUserEmailChannelOnChannelId(
                channel.ChannelId);
            if (userEmailChannelMaps != null)
            {
                userEmailChannelMaps.ForEach(x => this.userEmailChannelHandler.DeleteUserEmailChannel(x));
            }
            var channelBranding = this.channelHandler.RetrieveChannelBrandingByChannelId(channel.ChannelId);
            if (channelBranding != null)
            {
                this.channelHandler.DeleteChannelBranding(channelBranding);
            }
            
            this.channelHandler.DeleteChannel(channel);
        }

        public int AddBrandingForChannel(ChannelBrandingModel channelBrandingModel)
        {
            var channelBranding =
                new ChannelBranding
                {
                    IconUrl = channelBrandingModel.IconUrl ?? Constants.ServerUrl + "icons/default.png",
                    PrimaryColor = channelBrandingModel.PrimaryColor,
                    SecondaryColor = channelBrandingModel.SecondaryColor,
                    TertiaryColor = channelBrandingModel.TertiaryColor,
                    ChannelId = channelBrandingModel.ChannelId,
                    ChannelBrandingId = channelBrandingModel.ChannelBrandingId
                };
                
            this.channelHandler.UpdateChannelBranding(channelBranding);
            return channelBrandingModel.ChannelId;
        }

        public ChannelBrandingModel RetrieveChannelBrandingByChannelId(int channelId)
        {
            var channelBranding = this.channelHandler.RetrieveChannelBrandingByChannelId(channelId);
            if (channelBranding != null)
            {
                var channelBrandingModel = new ChannelBrandingModel(channelBranding);
                return channelBrandingModel;
            }
            return null;
        }

        public ChannelListModel RetrieveChannelsByLocationAndUser(float latitude, float longitude, int userId)
        {
            var channels = this.channelHandler.RetrieveChannelsByLocationAndUser(latitude, longitude, userId);
            if (channels != null && channels.Count > 0)
            {
                var channelListModel = new ChannelListModel();
                var channelsDummy = channels.Select(channel => new ChannelModelResponse(channel) { IsAuthenticated = channel.IsPublic ? true : channel.UserChannelMaps.Single(x => x.UserId == userId).Otp == null }).ToList();
                channelListModel.Channels = channelsDummy;
                return channelListModel;
                /*return new ChannelListModel()
                {
                    Channels = channels.Select(x => new ChannelModelResponse(x)).ToList()
                };*/
            }
            return null;
        }


        private ChannelListModel RetrieveChannelsByAdmin(int adminId)
        {
            var channels = this.channelHandler.RetrieveChannelsOnAdmin(adminId);
            if (channels != null)
            {
                ChannelListModel channelListModel = new ChannelListModel()
                                                        {
                                                            Channels =
                                                                channels.Select(
                                                                    x => new ChannelModelResponse(x))
                                                                .ToList()
                                                        };
                return channelListModel;
            }
            return new ChannelListModel();
        }

        public ChannelModel GetChannelOnText(string searchText)
        {
            var channel = this.channelHandler.GetChannelOnText(searchText);
            if (channel != null)
            {
                var channelModel = new ChannelModel(channel);
                return channelModel;
            }
            return null;
        }

        public ChannelViewModel GetChannel(int channelId)
        {
            var channel = this.channelHandler.RetrieveChannel(channelId);
            if (channel != null)
            {
                var channelModel = new ChannelViewModel
                {
                    IsLocationBased = channel.IsLocationBased,
                    IsPublic = channel.IsPublic,
                    Name = channel.Name,
                    ChannelId = channel.ChannelId,
                    Description = channel.Description,
                    Latitude = channel.Latitude,
                    Longitude = channel.Longitude,
                    TimeOfActivation = DateTime.ParseExact(channel.TimeOfActivation, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    TimeOfDeactivation = DateTime.ParseExact(channel.TimeOfDeactivation, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                };
                return channelModel;
            }
            return null;
        }

        public List<Channel> GetChannelsForAdmin(int adminId)
        {
            var admin = new AdminBusiness().RetrieveAdmin(adminId);
            if (admin.IsSuperAdmin)
            {
                return channelHandler.RetrieveAllChannels();
            }
            else
            {
                //TODO Channels For Admin
                return channelHandler.RetrieveChannelsOnAdmin(adminId);
            }
        }
    }
}