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
    public class MessageController : ApiController
    {
        private IDataGetter data;

        public MessageController(IDataGetter data)
        {
            this.data = data;
        }

        // GET: api/Message
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Message
        // id is the id of contact
        public IHttpActionResult Post(int id, [FromBody]Message message)
        {
            if (ModelState.IsValid)
            {
                message.ContactsId = id;
                data.AddMessage(message);
                return Ok(message);
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
