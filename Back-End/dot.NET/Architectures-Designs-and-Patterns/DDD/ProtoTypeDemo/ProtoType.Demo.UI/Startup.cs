using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(ProtoType.Demo.UI.Startup))]

namespace ProtoType.Demo.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888



            GlobalConfiguration.Configuration.UseSqlServerStorage(@"Server=.\sqlexpress; Database=HangFireDemoDB; Integrated Security=SSPI;");

            //BackgroundJob.Enqueue(() => Console.WriteLine("Getting Started with HangFire!"));

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
