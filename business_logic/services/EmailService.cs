using business_logic.services.interfaces;
using data.models.entities;
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
        public bool SendEmail(EmailBody email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                /*var cred_mail = _config.GetSection("Credentials")["Email"];
                var cred_password = _config.GetSection("Credentials")["Password"];*/
                var cred_mail = "omer";
                var cred_password = "omer";
                mail.To.Add("receiver");
                mail.From = new MailAddress(cred_mail);
                mail.ReplyToList.Add(cred_mail);
                mail.Subject = "";
                mail.Body = $"";
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

                return false;
            }
        }
    }
}
