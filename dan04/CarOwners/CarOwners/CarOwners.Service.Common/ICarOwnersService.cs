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
        Task<List<Person>> GetAllAsync(int pageNumber, string sort);
        Task<List<Car>> GetPersonCarAsync(int person_id);
        Task<string> NewPersonAsync(Person person);
        Task<string> UpdateCarAsync(int person_id, Car car);
        Task<string> DeleteCarAsync(int person_id, Car car);

    }
}
