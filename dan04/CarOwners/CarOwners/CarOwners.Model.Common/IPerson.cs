using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners.Model.Common
{
    public interface IPerson
    {
        int PersonId { get; set; }
        string FullName { get; set; }
        int Age { get; set; }

    }
}
