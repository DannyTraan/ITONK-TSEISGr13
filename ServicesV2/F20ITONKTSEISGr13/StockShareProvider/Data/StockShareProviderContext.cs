using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockShareProvider.Models;

namespace StockShareProvider.Data
{
    public class StockShareProviderContext : DbContext
    {
        public StockShareProviderContext (DbContextOptions<StockShareProviderContext> options)
            : base(options)
        {
        }

        public DbSet<StockShareProvider.Models.Stock> Stock { get; set; }
    }
}
