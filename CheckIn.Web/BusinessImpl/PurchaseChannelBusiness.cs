using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Data.Entities;
using CheckIn.Web.Business;
using CheckIn.Web.Common;
using CheckIn.Web.Models;
using CheckIn.Web.Models.Admin;
using CheckIn.Web.Models.Channel;
using CheckIn.Web.Models.Purchase;
using CheckIn.Web.Utilities;

namespace CheckIn.Web.BusinessImpl
{
    public class PurchaseChannelBusiness : IPurchaseChannelBusiness
    { 
        private IAdminBusiness adminBusiness;

        private IChannelBusiness channelBusiness;

        private IAdminChannelMapBusiness adminChannelMapBusiness;

        public PurchaseChannelBusiness()
        {
            this.adminBusiness = new AdminBusiness();
            this.channelBusiness = new ChannelBusiness();
            this.adminChannelMapBusiness = new AdminChannelMapBusiness();
        }
        
        public void AutoProvisionAdminChannel(PurchaseChannelModel purchaseChannelModel)
        {
            var channelModel = new ChannelViewModel()
            {
                Name = purchaseChannelModel.ChannelName,
                Description = purchaseChannelModel.Description
            };
            int channelId = this.channelBusiness.AddChannel(channelModel);
            var admin = this.adminBusiness.RetrieveAdminOnEmail(purchaseChannelModel.Email);
            if (channelId > 0)
            {
                if (admin == null)
                {
                    var adminModel = new AdminModel()
                    {
                        Email = purchaseChannelModel.Email,
                        Name = purchaseChannelModel.AdminName
                    };
                    int adminId = this.adminBusiness.AddAdmin(adminModel);
                    if (adminId > 0)
                    {
                        this.adminChannelMapBusiness.AddAdminChannelMap(new AdminChannelMapModel()
                        {
                            AdminId = adminId,
                            ChannelId = channelId
                        });
                    }
                }
                else
                {
                    this.adminChannelMapBusiness.AddAdminChannelMap(new AdminChannelMapModel()
                    {
                        AdminId = admin.AdminId,
                        ChannelId = channelId
                    });
                }
                EmailGateway.SendMail(new EmailModel()
                {
                    Body = string.Format(Constants.AutoProvisionAdminChannelBody, purchaseChannelModel.AdminName, purchaseChannelModel.ChannelName, AutoGeneratePasswordUtility.GeneratePassword() ,Constants.ServerUrl),
                    Subject = Constants.AutoProvisionAdminChannelSubject,
                    To = purchaseChannelModel.Email
                });
            }
        }
    }
}