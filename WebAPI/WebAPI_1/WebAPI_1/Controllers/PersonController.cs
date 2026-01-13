using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_1.Models;

namespace WebAPI_1.Controllers
{
    [RoutePrefix("User")]
    public class PersonController : ApiController
    {
        static List<Person> personslist = new List<Person>()
        { 
            new Person{Id=1, PersonName = "Yudhishter", PersonJob = "King", Gender="Male"},
            new Person{Id=2, PersonName = "Draupadi", PersonJob = "Queen", Gender="Female"},
            new Person{Id=3, PersonName = "Bheem", PersonJob = "Defence Minister", Gender="Male"},
            new Person{Id=4, PersonName = "Arjun", PersonJob = "Archerer", Gender="Male"},
            new Person{Id=5, PersonName = "Nakul", PersonJob = "Operations", Gender="Male"},
        };

        [HttpGet]
        [Route("All")]
        public IEnumerable<Person> Get()
        {
            return personslist;
        }

        [HttpGet]
        [Route("Bymsg")]
        public HttpResponseMessage GetAllPersons()
        {
            //creating a response object with both the data and status
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,personslist);

            //incase we want to send only response and no data
          //  HttpResponseMessage r = new StringContent("Thanks");
            return response;
        }

        //get name by id
        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetPersonsName_byId(int pid)
        {
            string pname = personslist.Where(p=>p.Id==pid).SingleOrDefault()? .PersonName;
            if(pname == null)
            {
                return NotFound();
            }
            return Ok(pname);
        }

        //post 1
        [HttpPost]
        [Route("AllPost")]
        public List<Person> PostAll([FromBody] Person person)
        {
            personslist.Add(person);
            return personslist;
        }

        //post 2

        [HttpPost]
        [Route("Personp")]
        public IEnumerable<Person> PersonPost([FromUri] int id, string name, string job)
        {
            Person person = new Person();
            person.Id = id;
            person.PersonName = name;
            person.PersonJob = job;
            personslist.Add(person);
            return personslist;
        }

        [HttpPut]
        [Route("updperson")]
        public Person Put(int pid, [FromUri] string name, string job, string gender)
        {
            var plist = personslist[pid -1];
            plist.Id = pid;
            plist.PersonName = name;
            plist.PersonJob = job;
            plist.Gender = gender;
            return plist;
        }

        //delete

        [HttpDelete]
        [Route("delperson")]
       public IEnumerable<Person> Delete(int pid)
        {
            personslist.RemoveAt(pid - 1);
            return personslist;
        }
    }

}
