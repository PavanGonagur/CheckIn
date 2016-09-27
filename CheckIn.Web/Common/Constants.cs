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

    }
}