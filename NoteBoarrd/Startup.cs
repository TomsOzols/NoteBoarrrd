using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NoteBoarrd.Startup))]
namespace NoteBoarrd
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
