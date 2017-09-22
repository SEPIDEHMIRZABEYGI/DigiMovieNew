using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace DigiMovei.Helper
{
     public enum EmailType { Empty, Info }

    public  static class Email
    {
        public static MailAddress GetMailName(EmailType type)
        {
            if (type == EmailType.Empty)
                return new MailAddress("sepideh.mirzabeygi@gmail.com");
            else
            { return new MailAddress("sepideh.mirzabeygi@gmail.com"); }
        }

        public static MailAddress GetMailAddress(EmailType type)
        {
            if (type == EmailType.Empty)
                return new MailAddress("sepideh.mirzabeygi@gmail.com");
            else
                return new MailAddress("sepideh.mirzabeygi@gmail.com", "دیجی مووی");
        }

        public static SmtpClient GetSmtp(EmailType type)
        {
            if (type == EmailType.Empty)
                return new SmtpClient();
            else
                return new SmtpClient
                {
                    Host = "sepideh.mirzabeygi@gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("sepideh.mirzabeygi@gmail.com", "410se410")
                };
        }
    }
}