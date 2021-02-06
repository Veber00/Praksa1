using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Model.Common;

namespace CarOwners.Model
{
    public class Person : IPerson
    {
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

    }
}
