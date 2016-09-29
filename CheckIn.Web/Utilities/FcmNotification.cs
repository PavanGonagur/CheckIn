using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using CheckIn.Web.Utilities.Interface;

namespace CheckIn.Web.Utilities
{
    public class FcmNotification : INotification
    {
        private const string GoogleAppID = "AIzaSyCupX5MIWo_kEJnX-f6C9HMHvyVSCkwA_w";
        
        public bool SendNotification(string value)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                Request.Method = "POST";
                Request.ContentType = "application/json";
                Request.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));
                Byte[] byteArray = Encoding.UTF8.GetBytes(value);
                Request.ContentLength = byteArray.Length;

                Stream dataStream = Request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    return false;
                }
                dataStream = Response.GetResponseStream();
                StreamReader Reader = new StreamReader(dataStream);
                String sResponseFromServer = Reader.ReadToEnd();
                Reader.Close();
                dataStream.Close();
                Response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public enum ResourceType
        {
            Profiles,

            Url,

            Application,

            Contact,

            Venue,

            ChatRoom
        }
    }
}