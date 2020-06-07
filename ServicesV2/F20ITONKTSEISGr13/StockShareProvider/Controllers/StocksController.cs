using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PublicShareOwnerControl.Models;
using StockShareProvider.Data;
using StockShareProvider.Models;

namespace StockShareProvider.Controllers
{
    [Route("api/StockShareProviderController")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly StockShareProviderContext _context;
        private readonly HttpClient PublicShareOwnerControlClient;
        //private readonly HttpClient StockTraderBrokerClient;

        public StocksController(StockShareProviderContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            PublicShareOwnerControlClient = clientFactory.CreateClient("psocclient");
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<List<StockInformation>> GetStocks()
        {
            var result = new List<StockInformation>();
            var response = await PublicShareOwnerControlClient.GetAsync($"api/StockInformationsController");

            using (response)
            {
                result = JsonConvert.DeserializeObject<List<StockInformation>>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        /*
        // POST: api/Stocks
        [HttpPost]
        public async Task<ActionResult<Stock>> RequestTransaction(Stock stock, StockInformation stockInformation)
        {
            _context.Stock.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.StockId }, stock);
        }
        */
    }
}
