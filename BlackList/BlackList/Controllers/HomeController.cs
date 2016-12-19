using BlackList.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BlackList.Hubs;

namespace BlackList.Controllers
{
    [Authorize]
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
            

           // string UserName = currentLoggedInUser();

            var newFriendsUserId = (from customer in _context.Users
                                    where customer.UserName == userName
                                    select customer.Id).SingleOrDefault();

            if (newFriendsUserId == null)
            {

                TempData["Error"] = "error message";
                Session["ComputerNumber"] = "error message";

            }
            else
            {
                string id = User.Identity.GetUserId<string>();

            var newFriendsUserId = (from customer in _context.Users
                           where customer.UserName == findFriendsUserId
                           select customer.Id).SingleOrDefault();
            
            if (newFriendsUserId == null)
            {
                //ViewBag.Message = TempData["shortMessage"].ToString();
                //return RedirectToAction("Action2");
                string query = "INSERT INTO dbo.Friends(UserID,FriendID) VALUES ('" + id + "', '" + newFriendsUserId + "')";
                _context.Database.ExecuteSqlCommand(query);
                _context.SaveChanges();

            }


            TempData["message"] = "someMessage";
            return View("TestController/Index");
        }
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

       




    }
}
