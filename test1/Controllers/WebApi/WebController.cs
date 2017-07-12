using MyLibrary;
using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace test1.Controllers.WebApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class WebController : ApiController
    {

        private static IDataGetter data = new DataGetter();

        public IDictionary<int, Contact> GetContacts()
        {
            return data.GetContacts();

        }
        

        public IHttpActionResult GetContact(int id)
        {
            try
            {
                return Ok(data.GetContact(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }   

        }


        public IHttpActionResult DeleteContact(int id)
        {
            try
            {
                data.Remove(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

        }


        public IHttpActionResult PostContact( [FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                data.AddContact(contact);
                return Ok(contact);
            }
            else
            {
                return BadRequest();
            }
            
        }


        public IHttpActionResult PutContact(int id, [FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.Update(id, contact);
                    return Ok();
                }
                catch (KeyNotFoundException)
                {
                    // maybe not found()
                    return BadRequest();
                }
                
            }
            else
            {
                return BadRequest();
            }
          
        }

    }
}
