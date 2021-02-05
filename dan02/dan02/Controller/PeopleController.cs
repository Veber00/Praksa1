using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dan02.Models;

namespace dan02.Controller
{
    public class PeopleController : ApiController
    {

        static List<Person> people = new List<Person>()
        {
            new Person{FirstName="Joseph", LastName="Thomposon", Id=1},
            new Person{FirstName="Rory", LastName="Anderson", Id=2},
            new Person{FirstName="Andrew", LastName="Ware", Id=3}
        };

        [Route("api/People/GetIds")]
        [HttpGet]
        public IHttpActionResult GetIds()
        {
            List<int> output = new List<int>();

            foreach(var p in people)
            {
                output.Add(p.Id);
            }

            return Ok(output);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(people);
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            Person person = people.Where(x => x.Id == id).FirstOrDefault();
            if(person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not found.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, person);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddPerson([FromBody]Person value)
        {
            Person person = people.Where(x => x.Id == value.Id).FirstOrDefault();
            if(person == null)
            {
                people.Add(value);
                return Request.CreateResponse(HttpStatusCode.Accepted, "Person added to list!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, "Person with this Id already exists!");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Person person = people.Where(x => x.Id == id).FirstOrDefault();
            if(person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Person not found!");
            }
            else
            {
                people.Remove(person);
                return Request.CreateResponse(HttpStatusCode.Accepted, "Person with id " + id + " removed!");
            }
        }
    }
}
