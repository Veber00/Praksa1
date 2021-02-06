using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Model;

namespace CarOwners.Service.Common
{
    public interface ICarOwnersService
    {
        List<string> GetAll();
        List<string> GetPersonCar(int person_id);
        string NewPerson(Person person);
        string UpdateCar(int person_id, Car car);
        string DeleteCar(int person_id, Car car);

    }
}
