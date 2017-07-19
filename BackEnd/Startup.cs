using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using BackEnd.App_Start;

[assembly: OwinStartup(typeof(BackEnd.Startup))]

namespace BackEnd
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
                ExpireTimeSpan = new TimeSpan(0, 30, 0),
                //LoginPath = new PathString("/api/nogo")
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseFacebookAuthentication(new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions
            {
                AppId = "332631000499026",
                AppSecret = "b8285f5d1509ed1ef76dcd8aa685d563"
            });

            WebApiConfig.Register(app, config);
            DIConfig.Register();
        }
    }
}
