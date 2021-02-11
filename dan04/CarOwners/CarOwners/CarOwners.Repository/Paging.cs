using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwners.Repository
{
    class Paging
    {
        
        public static int ResultsPerPage = 10;
        public static int NumberOfItems { get; set; }

        public static int NumberOfPages()
        {
            if (NumberOfItems == 0)
            {
                return 1;
            }
            else
            {
                return (int)Math.Ceiling((double)(NumberOfItems / ResultsPerPage));
            }
        }
    }
}
