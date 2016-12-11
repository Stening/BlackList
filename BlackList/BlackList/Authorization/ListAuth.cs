
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BlackList.Authorization
{
    enum ListRoles { Creator = 1, Admin = 2,Member = 3,Invited = 4}

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ListAuth : AuthorizeAttribute
    {
        public static BlackList.BusinessLayer.BlackListDbBusinessLayer dbLayer = new BusinessLayer.BlackListDbBusinessLayer();

        public new string Roles { get; set; }

        public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            var test = hubIncomingInvokerContext.Args;
            
            //string listId = httpContext.Request.RequestContext.RouteData.Values["listId"] as string;
            //int ListIdInt = int.Parse(listId);


            //string userMail = httpContext.User.Identity.Name;

            //var AuthorizationRole = dbLayer.GetAuthorizationRole(userMail, ListIdInt);

            //if (AuthorizationRole <= (int)Enum.Parse(typeof(ListRoles), Roles))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;

            //return base.AuthorizeCore(httpContext);//Should we use this even??
        }



        //protected override bool UserAuthorized(System.Security.Principal.IPrincipal user)
        //{
        //    return false;
        //}


    }
}