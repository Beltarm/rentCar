using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rentCar.Startup))]
namespace rentCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
