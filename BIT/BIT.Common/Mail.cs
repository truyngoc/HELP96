using System;
using System.Net.Mail;
using System.Configuration;
using System.Text;

namespace BIT.Common
{
    public class Mail
    {
        public static string Send(string toAddress, string subject, string body)
        {

            var sendMailFrom = ConfigurationManager.AppSettings["MailFrom"];
            var PasssendMailFrom = ConfigurationManager.AppSettings["PassMailFrom"];

            string result = "Message Sent Successfully..!!";
            string senderID = sendMailFrom;
            // use sender’s email id here..
            string senderMAT_KHAU = PasssendMailFrom;
            // sender MAT_KHAU here…
            try
            {
                // smtp server address here…
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    //Port = 587,
                    //Host = "mail.bitquick24.org",
                    //Port = 25,
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 30000,
                    UseDefaultCredentials = false
                };
                //smtp.Credentials = new System.Net.NetworkCredential();
                smtp.Credentials = new System.Net.NetworkCredential(senderID,senderMAT_KHAU);



                MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                message.IsBodyHtml = true;
                message.BodyEncoding = System.Text.UTF8Encoding.UTF8;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
            }

            return result;
        }


        //using System.Net.Mail;
        //using System.Text;

        //...

        //// Command line argument must the the SMTP host.
        //SmtpClient client = new SmtpClient();
        //client.Port = 587;
        //client.Host = "smtp.gmail.com";
        //client.EnableSsl = true;
        //client.Timeout = 10000;
        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //client.UseDefaultCredentials = false;
        //client.Credentials = new System.Net.NetworkCredential("user@gmail.com","password");

        //MailMessage mm = new MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");
        //mm.BodyEncoding = UTF8Encoding.UTF8;
        //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //client.Send(mm);
    }
}
