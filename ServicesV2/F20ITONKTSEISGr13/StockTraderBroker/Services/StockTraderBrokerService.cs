using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTraderBroker.Models;
using StockTraderBroker.Repositories;

namespace StockTraderBroker.Services
{
    public class StockTraderBrokerService : IStockTraderBrokerService
    {
        private IStockTraderBrokerRepository _repos;

        public StockTraderBrokerService(IStockTraderBrokerRepository repos)
        {
            _repos = repos;
        }

        public void AddStockTrade(SellerDto sellerDto)
        {
            StockTrade stockTrade = new StockTrade
            {
                StockSellerId = sellerDto.StockSellerId,
                TransferStockId = sellerDto.TransferStockId,
                StockPrice = sellerDto.StockPrice,
                StockAmount = sellerDto.StockAmount,
                StockTransferComplete = false,
                TransactionComplete = false
            };
            _repos.AddStockTrade(stockTrade);
        }

        public StockTrade UpdateBuyerOnStockTrade(int stockTradeId, int buyerId)
        {
            StockTrade stockTrade = _repos.GetById(stockTradeId);
            if (stockTrade != null)
            {
                stockTrade.StockBuyerId = buyerId;
                _repos.UpdateStockTrade(stockTrade);
                return stockTrade;
            }
            else
            {
                return null;
            }
        }

        public void DeleteStockTrade(int id)
        {
            _repos.DeleteStockTrade(id);
        }

        public List<StockTrade> GetStockTrades()
        {
            return _repos.GetStockTrades();
        }
    }
}
