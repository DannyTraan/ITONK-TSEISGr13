using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockTransactionItems.Models;

namespace StockTransactionItems.Data
{
    public class StockTransactionItemsContext : DbContext
    {
        public StockTransactionItemsContext (DbContextOptions<StockTransactionItemsContext> options)
            : base(options)
        {
        }

        public DbSet<StockTransactionItems.Models.Stock> Stocks { get; set; }
    }
}
