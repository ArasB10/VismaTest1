using MyLibrary;
using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackEnd.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class ContactController : ApiController
    {

        private IDataGetter data = new DbGetter();

        // GET: api/Contact
        public IDictionary<int, Contact> Get()
        {
            return data.GetContacts();
        }

        // GET: api/Contact/5
        public IHttpActionResult Get(int id)
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

        // POST: api/Contact
        public IHttpActionResult Post([FromBody]Contact contact)
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

        // PUT: api/Contact/5
        public IHttpActionResult Put(int id, [FromBody] Contact contact)
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

        // DELETE: api/Contact/5
        public IHttpActionResult Delete(int id)
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
    }
}
