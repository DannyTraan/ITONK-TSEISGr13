using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Services
{
    public interface IStockTraderBrokerService
    {
        void AddStockTrade(SellerDto sellerDto);
        StockTrade UpdateBuyerOnStockTrade(int stockTradeId, int buyerId);
        void DeleteStockTrade(int id);
        List<StockTrade> GetStockTrades();
        
    }
}
