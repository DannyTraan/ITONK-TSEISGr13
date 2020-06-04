using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StockTransactionItems.Models;

namespace StockTransactionItems.Repositories
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetListOfStocks();
        Stock GetStockById(int id);
        void AddStock(Stock stock);
        void RemoveStock(int id);
        void Save();
    }
}
