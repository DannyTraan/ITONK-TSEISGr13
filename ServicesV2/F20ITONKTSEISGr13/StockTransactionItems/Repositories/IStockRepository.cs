using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StockTransactionItems.Models;

namespace StockTransactionItems.Repositories
{
    interface IStockRepository
    {
        List<Stock> GetListOfStocks();
        Stock GetById(int id);
        void AddStock(Stock stock);
        void RemoveStock(int id);
    }
}
