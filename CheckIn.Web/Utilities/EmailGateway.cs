using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Utilities
{
    using System.Net.Mail;

    using CheckIn.Web.Models;

    public class EmailGateway
    {
        public static void SendMail(EmailModel emailModel)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("raybackclinton@gmail.com");
                mail.To.Add(emailModel.To);
                mail.Subject = emailModel.Subject;
                mail.Body = emailModel.Body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("raybackclinton@gmail.com", "wwerayback1");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}