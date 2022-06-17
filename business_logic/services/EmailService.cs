using business_logic.services.interfaces;
using data.models.entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace business_logic.services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public bool SendEmail(EmailBody email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                var cred_mail = _config.GetSection("cred_email").Value;
                var cred_password = _config.GetSection("cred_password").Value;
              
                mail.To.Add(email.Receiver);
                mail.From = new MailAddress(cred_mail);
                mail.ReplyToList.Add(cred_mail);
                mail.Subject = email.Subject;
                mail.Body = email.Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(cred_mail, cred_password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }
    }
}
