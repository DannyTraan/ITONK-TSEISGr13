using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockShareRequester.Models;

namespace StockShareRequester.Data
{
    public class StockShareRequesterContext : DbContext
    {
        public StockShareRequesterContext (DbContextOptions<StockShareRequesterContext> options)
            : base(options)
        {
        }

        public DbSet<StockShareRequester.Models.Requester> Requester { get; set; }
    }
}
