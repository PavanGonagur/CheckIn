using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Utilities
{
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Text;

    public class SMSGateway
    {
        public static string SendSms(string smsText, string sendTo)
        {
            #region Variables 
            string userId = ConfigurationManager.AppSettings["SMSGatewayUserID"];
            string pwd = ConfigurationManager.AppSettings["SMSGatewayPassword"];
            string postURL = ConfigurationManager.AppSettings["SMSGatewayPostURL"];

            StringBuilder postData = new StringBuilder();
            string responseMessage = string.Empty;
            HttpWebRequest request = null;
            #endregion

            try
            {
                // Prepare POST data 
                //Parameters will change depending on the gateway we use 
                postData.Append("from=Sede");
                postData.Append("&username=" + userId);
                postData.Append("&password=" + pwd);
                postData.Append("&number=" + sendTo);
                postData.Append("&text=" + smsText);
                byte[] data = new System.Text.ASCIIEncoding().GetBytes(postData.ToString());

                // Prepare web request 
                request = (HttpWebRequest)WebRequest.Create(postURL);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                // Write data to stream 
                using (Stream newStream = request.GetRequestStream())
                {
                    newStream.Write(data, 0, data.Length);
                }

                // Send the request and get a response 
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Read the response 
                    using (StreamReader srResponse = new StreamReader(response.GetResponseStream()))
                    {
                        responseMessage = srResponse.ReadToEnd();
                    }
                }
                return responseMessage;
            }
            catch (Exception objException)
            {
                throw;
            }
        }
    }
}