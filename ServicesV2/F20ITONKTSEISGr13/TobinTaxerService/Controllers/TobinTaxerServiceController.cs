using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockShareRequester.Models;
using StockTraderBroker.Models;
using TobinTaxerService.Models;

namespace TobinTaxerService.Controllers
{
    [Route("api/TobinTaxerServiceController")]
    [ApiController]
    public class TobinTaxerServiceController : ControllerBase
    {
        private readonly HttpClient StockShareRequesterClient;

        public TobinTaxerServiceController(IHttpClientFactory clientFactory)
        {
            StockShareRequesterClient = clientFactory.CreateClient("ssrclient");
        }

        // Taxing the buyer
        [HttpPost]
        public async Task<IActionResult> TobinTaxerServiceBuyer([FromRoute] StockTrade stockTrade, [FromBody] TobinTaxerServiceModel tts)
        {
            var requester = new Requester();
            tts.TaxAmount = stockTrade.StockPrice * 0.015;
            requester.Balance -= tts.TaxAmount;

            var json = JsonConvert.SerializeObject(requester);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await StockShareRequesterClient.PutAsync($"api/StockShareRequesterController/{stockTrade.BuyerId}", stringContent);

            using (response)
            {
                await response.Content.ReadAsStringAsync();
            }

            return NoContent();
        }

        // Taxing the seller
        [HttpPost]
        public async Task<IActionResult> TobinTaxerServiceSeller([FromRoute] StockTrade stockTrade, [FromBody] TobinTaxerServiceModel tts)
        {
            var requester = new Requester();
            tts.TaxAmount = stockTrade.StockPrice * 0.025;
            requester.Balance -= tts.TaxAmount;

            var json = JsonConvert.SerializeObject(requester);
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await StockShareRequesterClient.PutAsync($"api/StockShareRequesterController/{stockTrade.SellerId}", stringContent);

            using (response)
            {
                await response.Content.ReadAsStringAsync();
            }

            return NoContent();
        }
    }
}