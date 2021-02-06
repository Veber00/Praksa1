using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarOwners.Service;
using CarOwners.Service.Common;
using CarOwners.Model;

namespace CarOwners.WebAPI.Controllers
{
    public class CarOwnersController : ApiController
    {

        protected ICarOwnersService service = new CarOwnersService();

        [HttpGet]
        [Route("api/GetAll")]
        public HttpResponseMessage GetAll()
        {

            List<string> ret = new List<string>();

            ret = service.GetAll();

            if(ret.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Table is empty!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, ret);
                
        }


        [HttpGet]
        [Route("api/GetPersonCar/{id}")]
        public HttpResponseMessage GetPersonCar(int person_id)
        {

            List<string> ret = new List<string>();

            ret = service.GetPersonCar(person_id);

            if (ret.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "This person doesn't have a car.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, ret);

        }

        [HttpPost]
        [Route("api/NewPerson")]
        public HttpResponseMessage NewPerson([FromBody] Person person)
        {

            string ret = service.NewPerson(person);

            if(ret == "OK")
            {
                return Request.CreateResponse(HttpStatusCode.OK, "New person added!");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ret);

        }

        [HttpPut]
        [Route("api/UpdateCar/{person_id}")]
        public HttpResponseMessage UpdateCar(int person_id, [FromBody] Car car)
        {

            string ret = service.UpdateCar(person_id, car);

            if (ret == "OK")
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Car is updated!");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ret);

        }

        [HttpDelete]
        [Route("api/DeleteCar/{person_id}")]
        public HttpResponseMessage DeleteCar(int person_id, [FromBody] Car car)
        {

            string ret = service.DeleteCar(person_id, car);

            if (ret == "OK")
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Car is deleted!");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ret);

        }

    }
}
