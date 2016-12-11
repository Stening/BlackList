
using BlackList.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlackList.Authorization
{
    enum ListRoles { Creator = 1, Admin = 2,Member = 3,Invited = 4}

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ListAuth : AuthorizeAttribute
    {
        public static IBlackListDbBusinessLayer _dbLayer;

        public new string Roles { get; set; }
        public ListAuth(IBlackListDbBusinessLayer dbLayer)
        {
            _dbLayer = dbLayer;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            
            string listId = httpContext.Request.RequestContext.RouteData.Values["listId"] as string;
            int ListIdInt = int.Parse(listId);


            string userMail = httpContext.User.Identity.Name;

            var AuthorizationRole = _dbLayer.GetAuthorizationRole(userMail, ListIdInt);

            if (AuthorizationRole <= (int)Enum.Parse(typeof(ListRoles), Roles))
            {
                return true;
            }
            else
            {
                return false;
            }


            //return base.AuthorizeCore(httpContext);//Should we use this even??
        }


    }
}