using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_3_Chapter_15.Models
{
    public class CalculationContext : DbContext
    {
        public CalculationContext(DbContextOptions<CalculationContext> opts)
            : base(opts) {}

        public DbSet<Calculation> Calculations { get; set; }
    }
}
