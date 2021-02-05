using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dan03.Models
{
    public class Car
    {
        public int CarsOwnedId { get; set; }
        public int PersonId { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public int CarMillage { get; set; }

    }
}