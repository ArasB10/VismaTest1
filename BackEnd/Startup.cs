using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using BackEnd.App_Start;
using System.Threading.Tasks;
using System.Security.Claims;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
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
                AppSecret = "b8285f5d1509ed1ef76dcd8aa685d563",
                Provider = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationProvider()
                {
                    OnAuthenticated = (context) =>
                    {
                        //context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:access_token", context.AccessToken, XmlSchemaString, "Facebook"));
                        //context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:email", context.Email, XmlSchemaString, "Facebook"));
                        //context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:email", context.Email, ClaimValueTypes.String, "Facebook"));
                        context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:access_token", context.AccessToken, ClaimValueTypes.String, "Facebook"));
                        context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:name", context.User.Value<string>("name"), ClaimValueTypes.String, "Facebook"));

                        return Task.FromResult(0);
                    }
                }
            });

            WebApiConfig.Register(app, config);
            DIConfig.Register();
        }
    }
}
