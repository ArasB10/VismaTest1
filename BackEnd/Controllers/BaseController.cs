using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace BackEnd.Controllers
{

    // playing around with facebook claims, does not work
    public class BaseController: ApiController
    {
        public IOwinContext CurrentOwinContext
        {
            get
            {

                return HttpContext.Current.GetOwinContext();
            }
        }

        public IAuthenticationManager Authentication
        {
            get
            {
                return CurrentOwinContext.Authentication;
            }
        }

        public new ClaimsPrincipal User
        {
            get
            {
                return Authentication.User;
            }
        }

        public ClaimsIdentity Identity
        {
            get
            {
                return Authentication.User.Identity as ClaimsIdentity;
            }
        }

       
        public string FacebookAccessToken
        {
            get
            {
                var claim = Identity.FindFirst("urn:facebook:access_token");

                if (claim == null)
                    return null;

                return claim.Value;
            }
        }

        [HttpGet]
        [Route("api/token")]
        public string GetToken()
        {
            var claim = Identity.FindFirst("urn:facebook:access_token");

            if (claim == null)
                return null;

            return claim.Value;
        }
    }
}