using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Configuration;
//using System.Web.Configuration;
using System.Net.Configuration;
using System.Web;

namespace Infrastructure.Helper
{
    public class SMTP_Email {

        public SMTP_Email() {
           
        }
        public void SendBy(string to, string subject, string body)
        {
            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            var smtpClient = new SmtpClient();
           // smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
    
}
