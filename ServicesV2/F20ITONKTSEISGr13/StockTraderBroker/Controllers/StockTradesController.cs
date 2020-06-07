using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockShareRequester.Models;
using StockTraderBroker.Data;
using StockTraderBroker.Models;
using PublicShareOwnerControl.Models;

namespace StockTraderBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTradesController : ControllerBase
    {
        private readonly StockTraderBrokerContext _context;
        private readonly HttpClient PublicShareOwnerControlClient;
        private readonly HttpClient StockShareRequestClient;
        //private readonly HttpClient TobinTaxerServiceClient;

        public StockTradesController(IHttpClientFactory clientFactory, StockTraderBrokerContext context)
        {
            PublicShareOwnerControlClient = clientFactory.CreateClient("psocclient");
            StockShareRequestClient = clientFactory.CreateClient("ssrcclient");
            _context = context;
        }

        // Creates the transaction and adds to history
        // POST: api/StockTrades
        [HttpPost("{buyerId}")]
        public async Task<IActionResult> Transaction([FromRoute] int buyerId, int sellerId, [FromBody] IEnumerable<StockInformation> stockInformation)
        {
            var buyer = await GetBuyerId(buyerId);
            var seller = await GetSellerId(sellerId);
            CreateStockTradeTransaction(buyer, stockInformation);
            var updateStockInformation = await UpdateStockInformation(stockInformation, buyer);
            await UpdateBuyersBalance(buyer, stockInformation);
            await UpdateSellersBalance(seller, stockInformation);

            return Ok(updateStockInformation);
        }

        #region Methods

        // Creates the stocktrade transaction
        private IEnumerable<StockTrade> CreateStockTradeTransaction(Requester requester, IEnumerable<StockInformation> stockInformation)
        {
            var result = stockInformation.Select(stock => new StockTrade
            {
                OwnerId = requester.OwnerId,
                BuyerId = requester.BuyerId,
                SellerId = stock.SellerId,
                StockId = stock.StockId,
                StockPrice = stock.StockPrice
            }).ToList();

            return result;
        }

        // Updates PublicShareOwnerControl stockinformation on the specific stock that is being purchased
        private async Task<IEnumerable<StockInformation>> UpdateStockInformation(IEnumerable<StockInformation> stockInformation, Requester buyerId)
        {
            var result = new List<StockInformation>();
            foreach (var stock in stockInformation)
            {
                var request = new StockInformation
                {
                    OwnerId = buyerId.OwnerId,
                    BuyerId = buyerId.BuyerId,
                    SellerId = buyerId.SellerId,
                    StockId = stock.StockId,
                    StockName = stock.StockName,
                    StockPrice = stock.StockPrice
                };

                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await PublicShareOwnerControlClient.PutAsync($"api/StockInformationsController/{stock.StockId}", stringContent);

                using (response)
                {
                    result.Add(JsonConvert.DeserializeObject<StockInformation>(await response.Content.ReadAsStringAsync()));
                }
            }

            return result;
        }

        // Update the buyers balance status
        private async Task<IEnumerable<Requester>> UpdateBuyersBalance(Requester buyer, IEnumerable<StockInformation> stockInformation)
        {
            var result = new List<Requester>();
            foreach (var stock in stockInformation)
            {
                var buyerRequester = await GetBuyerId(buyer.BuyerId);
                buyerRequester.Balance -= stock.StockPrice;

                var json = JsonConvert.SerializeObject(buyerRequester);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await StockShareRequestClient.PutAsync($"api/StockShareRequesterController/{buyerRequester.BuyerId}", stringContent);

                using (response)
                {
                    if (!result.Select(x => x.BuyerId).Contains(buyerRequester.BuyerId))
                    {
                        result.Add(JsonConvert.DeserializeObject<Requester>(await response.Content.ReadAsStringAsync()));
                    }
                }
            }

            return result;            
        }

        // Update the Sellers balance status
        private async Task<IEnumerable<Requester>> UpdateSellersBalance(Requester seller, IEnumerable<StockInformation> stockInformation)
        {
            var result = new List<Requester>();
            foreach (var stock in stockInformation)
            {
                var sellerRequester = await GetSellerId(seller.SellerId);
                sellerRequester.Balance += stock.StockPrice;

                var json = JsonConvert.SerializeObject(sellerRequester);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await StockShareRequestClient.PutAsync($"api/StockShareRequesterController/{sellerRequester.SellerId}", stringContent);

                using (response)
                {
                    if (!result.Select(x => x.SellerId).Contains(sellerRequester.SellerId))
                    {
                        result.Add(JsonConvert.DeserializeObject<Requester>(await response.Content.ReadAsStringAsync()));
                    }
                }

            }
            return result;
        }

        // Get the buyers ID
        private async Task<Requester> GetBuyerId(int buyerId)
        {
            var result = new Requester();
            var response = await StockShareRequestClient.GetAsync($"api/StockShareRequesterController/{buyerId}");
            using (response)
            {
                result = JsonConvert.DeserializeObject<Requester>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        // Get the sellers ID
        private async Task<Requester> GetSellerId(int sellerId)
        {
            var result = new Requester();
            var response = await StockShareRequestClient.GetAsync($"api/StockShareRequesterController/{sellerId}");
            using (response)
            {
                result = JsonConvert.DeserializeObject<Requester>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        #endregion
    }
}
