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

        public List<string> GetAll()
        {
            return Rep.GetAll();
        }

        public List<string> GetPersonCar(int person_id)
        {
            return Rep.GetPersonCar(person_id);
        }

        public string NewPerson(Person person)
        {
            return Rep.NewPerson(person);
        }

        public string UpdateCar(int person_id, Car car)
        {
            return Rep.UpdateCar(person_id, car);
        }

        public string DeleteCar(int person_id, Car car)
        {
            return Rep.DeleteCar(person_id, car);
        }
    }
}
