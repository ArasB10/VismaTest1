using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackEnd.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class LoginController : ApiController
    {

        [HttpGet]
        [Route("api/login")]
        public HttpResponseMessage Login()
        {
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
