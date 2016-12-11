using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using BlackList.Models;
using System.Web.Mvc;
using BlackList.BusinessLayer.Interfaces;
using BlackList.Models.Interfaces;

//skechy!
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlackList.BusinessLayer
{
    public class bootstrapper
    {

        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
            return container;

        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();


            container.RegisterType<IApplicationDbContext, ApplicationDbContext>();

            //skechy!
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            //skechy!

            container.RegisterType<IBlackListDbBusinessLayer, BlackListDbBusinessLayer>();
            RegisterTypes(container);
            return container;

        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }



    }
}