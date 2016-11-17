using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Common
{
    public class Constants
    {
        public const string UserRegisterBody =
            "Hi you have been invited to attend {0} via CheckIn. Install and Register CheckIn application to get all configurations. Link to download";

        public const string UserRegisterSubject = "Invitation from event {0}";

        public const string PrivateChannelBody =
            "Hi you have been invited to attend {0} via CheckIn. This is private event, you will be asked to enter OTP once you reach the event venue.Your OTP {1}";

        public const string PrivateChannelSubject = "Invitation from event {0}";

        public const string PrivateChannelNoGeoBasedRestrictionBody = 
            "Hi you have been invited to attend {0} via CheckIn. Your OTP to login to channel is {1}";

        public const string AdminPasswordBody = "Hi {0}, your password to login CheckIn Console {1}. Link to CheckIn console {2}";

        public const string AdminPasswordSubject = "CheckIn console Password Information";

        public const string AutoProvisionAdminChannelBody = 
            "Hi {0}, your account is created and channel {1} is assigned to you successfully!. Please follow below link to add Resources to your channel, update admin information. Your Password to login is {2}. It is recommended to reset your password once you login. Link {3}";

        public const string AutoProvisionAdminChannelSubject = "CheckIn Admin and Channel Created";

        public const string ForgotPasswordBody = "Hi {0}, your password to login to CheckIn console {1}. It is Recommended to reset your password once you login.";

        public const string ForgotPasswordSubject = "CheckIn Forgot Password";

        public const string ServerUrl = "http://10.85.193.92/CheckIn/";

    }
}