using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_1.Controllers
{
    public class DemoController : ApiController
    {
        static List<string> continents = new List<string>()
        {
            "Asia",
            "Africa",
            "America",
            "Antartica",
            "Australia",
            "Europe"
        };

        //Get api/Demo
        public IEnumerable<string> Get()
        {
            return continents;
        }

        public string Get(int id)
        {
            return continents[id - 1];
        }

        public IEnumerable<string> Post([FromBody] string c) 
        { 
            continents.Add(c);
            return continents;
        }
        public IEnumerable<string>Put(int id, [FromUri]  string c)
        {
            continents[id - 1] = c;
            return continents;
        }

        public IEnumerable<string> Delete(int id)
        {
            continents.RemoveAt(id - 1);
            return continents;
        }
    }
}
