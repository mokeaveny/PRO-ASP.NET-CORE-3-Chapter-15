using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_3_Chapter_15.Models
{
    public class Calculation
    {
        // Creates the primary key in the DB
        public long Id { get; set; }
        // Describes the calculation
        public int Count { get; set; }
        // Describes the result
        public long Result { get; set; }
    }
}
