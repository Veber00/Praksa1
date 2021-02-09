using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarOwners.WebAPI.Models
{
    public class RestCar
    {

        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public int CarMillage { get; set; }

    }
}