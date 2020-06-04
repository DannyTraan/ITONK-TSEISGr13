using Microsoft.EntityFrameworkCore;

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
