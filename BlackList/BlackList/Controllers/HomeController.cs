using BlackList.Models;
using Microsoft.AspNet.SignalR.Messaging;
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
        public ActionResult Index()
        {
            string _currentLoggedInUser= currentLoggedInUser();
            ViewBag.EmployeeName = _currentLoggedInUser;
            return View();
        }

        private string currentLoggedInUser()
        {
            string activeUser = ControllerContext.HttpContext.User.Identity.Name;
            return activeUser;
        }

        [HttpPost]
        public ActionResult EmailInfo(string Email, string InviteUserName)
        {
            SendEmail(Email, InviteUserName);
            return RedirectToAction("Index");
        }

        public void SendEmail(string email, string InviteUserName)
        {
           string UserName = currentLoggedInUser();
            string fromaddr = "projectblacklistteam@gmail.com";
            string toaddr = email;//TO ADDRESS HERE
            string password = "alexander28";

            try
            {
                MailMessage msg = new MailMessage();
                msg.Subject = "projectblacklistteam alexander28";
                msg.From = new MailAddress(fromaddr);
                msg.Body = "Hej "+ InviteUserName+ "\n"+ UserName + " vill bjuda in dig till att använda BlackList,\nFölj länken nedan " + " www.?.de";
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
        [HttpPost]
        public ActionResult addNewFriend(string userName)
        {

            returnvalue(userName);

            string UserName = currentLoggedInUser();
            return RedirectToAction("Index");
        }
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        public string returnvalue(string findFriendsUserId)
        {


            var newFriendsUserId = (from customer in _context.Users
                           where customer.UserName == findFriendsUserId
                           select customer.Id).SingleOrDefault();
            
            if (newFriendsUserId == null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
                return RedirectToAction("Action2");
            }
           //string d= newFriendsUserId.ToString();
         //   string UserName = currentLoggedInUser();

            return newFriendsUserId.ToString();
        }
    }
}
