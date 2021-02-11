using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Service;
using CarOwners.Repository;
using CarOwners.Service.Common;
using CarOwners.Model;
using CarOwners.Repository.Common;

namespace CarOwners.Service
{
    public class CarOwnersService : ICarOwnersService
    {

        protected ICarOwnersRepository Rep { get; set; }
        public CarOwnersService(ICarOwnersRepository _repository)
        {
            this.Rep = _repository;
        }

        public async Task<List<Person>> GetAllAsync(int pageNumber, string sort)
        {
            return await Rep.GetAllAsync(pageNumber, sort);
        }

        public async Task<List<Car>> GetPersonCarAsync(int person_id)
        {
            return await Rep.GetPersonCarAsync(person_id);
        }

        public async Task<string> NewPersonAsync(Person person)
        {
            return await Rep.NewPersonAsync(person);
        }

        public async Task<string> UpdateCarAsync(int person_id, Car car)
        {
            return await Rep.UpdateCarAsync(person_id, car);
        }

        public async Task<string> DeleteCarAsync(int person_id, Car car)
        {
            return await Rep.DeleteCarAsync(person_id, car);
        }
    }
}
