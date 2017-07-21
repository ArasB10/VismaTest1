using log4net;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackEnd.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class LoginController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [HttpGet]
        [Route("api/login")]
        public HttpResponseMessage Login()
        {
            Log.Debug("Login Request traced");
            //var redirectUrl = Request.Headers.GetValues("Location").First();
            var properties = new AuthenticationProperties() { RedirectUri = "http://localhost:55885/list" };

            Request.GetOwinContext().Authentication.Challenge(properties, "Facebook");

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);

            response.RequestMessage = Request;

            return response;
        }

        //[Authorize]
        //[Route("api/surname")]
        //public IHttpActionResult GetSurname()
        //{
        //    return Ok("Labas");
        //}

        //[HttpGet]
        //[Route("api/nogo")]
        //public IHttpActionResult GetNoGo()
        //{
        //    return Ok("Neautorizuota");
        //}

    }
}
