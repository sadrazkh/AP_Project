using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace AP_Project.Back_End.Security
{
    public class MailSender
    {
        public static bool MailSend(string MailAdress,string RecoveryCode)
        {
            try
            {
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("sadra.z.kh@gmail.com", "AP Project");
                mailMessage.To.Add(MailAdress);
                mailMessage.Subject = "Password Recovery";
                mailMessage.Body = string.Format("Your Code is : {0}",RecoveryCode);

                mailMessage.IsBodyHtml = false;
                NetworkCredential credential = new NetworkCredential("sadra.z.kh@gmail.com", "********");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.Host = "smtp.gmail.com";

                smtp.Send(mailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool NewslettersSend(string[] MailAdress, string MailBody)
        {
            try
            {
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("sadra.z.kh@gmail.com", "AP Project");
                foreach(string Mailadress in MailAdress)
                {
                    mailMessage.To.Add(Mailadress);
                }
                mailMessage.Subject = "News letters";
                mailMessage.Body = string.Format("Newsletters \n\n {0}", MailBody);

                mailMessage.IsBodyHtml = false;
                NetworkCredential credential = new NetworkCredential("sadra.z.kh@gmail.com", "********");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.Host = "smtp.gmail.com";

                smtp.Send(mailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
