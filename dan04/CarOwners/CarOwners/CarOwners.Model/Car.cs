using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Model.Common;

namespace CarOwners.Model
{
    public class Car : ICar
    {
        public int CarsOwnedId { get; set; }
        public int PersonId { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public int CarMillage { get; set; }

    }
}
