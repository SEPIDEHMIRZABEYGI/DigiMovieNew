using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using DigiMovei.Helper;

namespace DigiMovei.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult SendEmail()
        {
            var message = new MailMessage
            {
                From = Email.GetMailAddress(EmailType.Info),
                Subject = "وب سایت دیجی مووی - بخش ارتباط با ما",
                Body = string.Format("نام : " +
                "{0}<hr>" +
                "ایمیل : " +
                "{1}<hr>" +
                "موضوع : " +
                "{2}<hr>" +
                "پیام : " +
                "{3}", Request.Form["name"], Request.Form["email"], Request.Form["subject"], Request.Form["body"]),
                IsBodyHtml = true
            };

            message.To.Add(Email.GetMailName(EmailType.Info));
            var smtp = Email.GetSmtp(EmailType.Info);

            try
            {
                smtp.Send(message);
                ViewBag.Status = 1;
            }
            catch
            {
                ViewBag.Status = 0;
            }

            return View("Contact");
        }

        [HttpPost]
        public ActionResult SetLayout(string layout)
        {
            return View("About", "~/Views/Shared/_" + layout + ".cshtml");
        }



    }
}