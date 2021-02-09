using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarOwners.Service;
using CarOwners.Service.Common;
using CarOwners.Model;
using System.Threading.Tasks;
using CarOwners.WebAPI.Models;

namespace CarOwners.WebAPI.Controllers
{
    public class CarOwnersController : ApiController
    {

        protected ICarOwnersService service = new CarOwnersService();

        [HttpGet]
        [Route("api/GetAll")]
        public async Task<HttpResponseMessage> GetAllAsync()
        {

            List<Person> ret = await service.GetAllAsync();
            List<RestPerson> restRet = new List<RestPerson>();

            if(ret.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Table is empty!");
            }

            foreach(Person person in ret)
            {
                restRet.Add(new RestPerson { FullName = person.FullName, Age = person.Age });
            }

            return Request.CreateResponse(HttpStatusCode.OK, restRet);
                
        }


        [HttpGet]
        [Route("api/GetPersonCar/{person_id}")]
        public async Task<HttpResponseMessage> GetPersonCarAsync(int person_id)
        {

            List<Car> ret = await service.GetPersonCarAsync(person_id);
            List<RestCar> restRet = new List<RestCar>();

            if (ret.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "This person doesn't have a car.");
            }

            foreach(Car car in ret)
            {
                restRet.Add(new RestCar { CarModel = car.CarModel, CarYear = car.CarYear, CarMillage = car.CarMillage });
            }

            return Request.CreateResponse(HttpStatusCode.OK, restRet);

        }

        [HttpPost]
        [Route("api/NewPerson")]
        public async Task<HttpResponseMessage> NewPersonAsync([FromBody] Person person)
        {

            string ret = await service.NewPersonAsync(person);

            if(ret == "OK")
            {
                return Request.CreateResponse(HttpStatusCode.OK, "New person added!");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ret);

        }

        [HttpPut]
        [Route("api/UpdateCar/{person_id}")]
        public async Task<HttpResponseMessage> UpdateCarAsync(int person_id, [FromBody] Car car)
        {

            string ret = await service.UpdateCarAsync(person_id, car);

            if (ret == "OK")
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Car is updated!");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ret);

        }

        [HttpDelete]
        [Route("api/DeleteCar/{person_id}")]
        public async Task<HttpResponseMessage> DeleteCarAsync(int person_id, [FromBody] Car car)
        {

            string ret = await service.DeleteCarAsync(person_id, car);

            if (ret == "OK")
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Car is deleted!");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ret);

        }

    }
}
