using BlackList.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace BlackList.Controllers
{
    
    public class HomeController : Controller
    {

        ShowAllUsers wigge = new ShowAllUsers();
        
        public ActionResult Index()
        {
            
            
            return View();
        }
        [HttpPost]
        public ActionResult EmailInfo(string Email, string InviteUserName,string UserName)
        {
            SendEmail(Email, InviteUserName,UserName);
            return RedirectToAction("Index");
        }

        public void SendEmail(string email, string InviteUserName, string UserName)
        {
            string fromaddr = "projectblacklistteam@gmail.com";
            string toaddr = email;//TO ADDRESS HERE
            string password = "alexander28";

            try
            {
                MailMessage msg = new MailMessage();
                msg.Subject = "projectblacklistteam alexander28";
                msg.From = new MailAddress(fromaddr);
                msg.Body = "Hej "+ InviteUserName+ "\n"+ UserName + " vill bjuda in dig till att använda BlackList,\nFölj länken nedan " + " www.string-emil.de";
                msg.To.Add(new MailAddress(toaddr));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential(fromaddr, password);
                smtp.Credentials = nc;
                smtp.Send(msg);

            }
            catch (Exception)
            {

                throw new ArgumentException("något gick fel");
            }
        }
    }
}
