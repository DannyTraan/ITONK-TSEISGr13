using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTransactionItems.Data;
using StockTransactionItems.Models;

namespace StockTransactionItems.Repositories
{
    public class StockRepository : IStockRepository
    {
        private StockTransactionItemsContext _context;

        public StockRepository(StockTransactionItemsContext context)
        {
            _context = context;
        }

        public List<Stock> GetListOfStocks()
        {
            return _context.Stocks.ToList();
        }

        public Stock GetById(int id)
        {
            return id != 0 ? _context.Stocks.Find(id) : null;
        }

        public void AddStock(Stock stock)
        {
            if (stock == null) return;
            _context.Stocks.Add(stock);
            _context.SaveChanges();
        }

        public void RemoveStock(int id)
        {
            _context.Stocks.Remove(_context.Stocks.Find(id));
            _context.SaveChanges();
        }
    }
}
