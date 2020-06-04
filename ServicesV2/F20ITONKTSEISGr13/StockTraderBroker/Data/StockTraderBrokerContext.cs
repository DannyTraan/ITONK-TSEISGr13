using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockTraderBroker.Models;

namespace StockTraderBroker.Data
{
    public class StockTraderBrokerContext : DbContext
    {
        public StockTraderBrokerContext (DbContextOptions<StockTraderBrokerContext> options)
            : base(options)
        {
        }

        public DbSet<StockTraderBroker.Models.StockTrade> StockTrade { get; set; }
    }
}
