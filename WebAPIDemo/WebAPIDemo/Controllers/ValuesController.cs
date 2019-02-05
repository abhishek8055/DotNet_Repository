using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        static List<string> names = new List<string>()
        {
            "Abhishek",
            "Durgesh",
            "Dheeraj"
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return names;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return names[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            names.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            names[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            names.RemoveAt(id);
        }
    }
}
