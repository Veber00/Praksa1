using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Service;
using CarOwners.Repository;
using CarOwners.Service.Common;
using CarOwners.Model;

namespace CarOwners.Service
{
    public class CarOwnersService : ICarOwnersService
    {

        protected CarOwnersRepository Rep { get; set; }
        public CarOwnersService()
        {
            Rep = new CarOwnersRepository();
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await Rep.GetAllAsync();
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
