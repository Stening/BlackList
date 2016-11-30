using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;


[assembly: OwinStartup(typeof(BlackList.Startup))]

namespace BlackList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR("/signalr", new HubConfiguration());
            //var sqlConnectionString = @"Server=(localdb)\v11.0;Database=BlackListRepository;Integrated Security=True;";
            //GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);
            //GlobalHost.DependencyResolver.

        }
        
        

    }
}
