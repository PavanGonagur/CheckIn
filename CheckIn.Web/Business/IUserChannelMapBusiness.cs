using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Models;
    using CheckIn.Web.Models.Channel;

    public interface IUserChannelMapBusiness
    {
        RegisterToChannelResponseModel RegisterToChannel(RegisterToChannelModel registerToChannelModel);

        void AddUserChannelMap(UserChannelMapModel userChannelMapModel);

        void ResendOtp(ResendOtpModel resendOtpModel);

        RegisterToChannelResponseModel GetPublicChannel(GetPublicChannelModel registerToChannelModel);
    }
}
