﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BlackList.Startup))]
namespace BlackList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
