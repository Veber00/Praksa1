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
using AutoMapper;

namespace CarOwners.WebAPI.Controllers
{
    public class CarOwnersController : ApiController
    {

        protected ICarOwnersService service;
        public CarOwnersController(ICarOwnersService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        [Route("api/GetAll")]
        public async Task<HttpResponseMessage> GetAllAsync([FromUri]int pageNumber, [FromUri]string sort)
        {

            List<Person> ret = await service.GetAllAsync(pageNumber, sort);
            List<RestPerson> restRet = new List<RestPerson>();


            if(ret.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Table is empty!");
            }

            var config = new MapperConfiguration(t => t.CreateMap<Person, RestPerson>());
            var mapper = config.CreateMapper();

            foreach (var person in ret)
            {
                RestPerson restPerson = mapper.Map<Person, RestPerson>(person);
                restRet.Add(restPerson);
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

            var config = new MapperConfiguration(t => t.CreateMap<Car, RestCar>());
            var mapper = config.CreateMapper();

            foreach(var car in ret)
            {
                RestCar restCar = mapper.Map<Car, RestCar>(car);
                restRet.Add(restCar);
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

        public class RestCar
        {

            public string CarModel { get; set; }
            public int CarYear { get; set; }
            public int CarMillage { get; set; }

        }

        public class RestPerson
        {
            public string FullName { get; set; }
            public int Age { get; set; }
        }

    }
}
