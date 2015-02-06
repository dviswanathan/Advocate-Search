using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAdvocateSearch.Startup))]
namespace WebAdvocateSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
