using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using BlackList.BusinessLayer;


[assembly: OwinStartup(typeof(BlackList.Startup))]

namespace BlackList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            bootstrapper.Initialize();
        }
    }
}
