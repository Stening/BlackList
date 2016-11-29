using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ShoppingList.Startup))]
namespace ShoppingList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //GlobalHost.HubPipeline.AddModule(new RejoingGroupPipelineModule());
        }
    }
}
