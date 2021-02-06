using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners.Model.Common
{
    public interface ICar
    {
        int CarsOwnedId { get; set; }
        int PersonId { get; set; }
        string CarModel { get; set; }
        int CarYear { get; set; }
        int CarMillage { get; set; }

    }
}
