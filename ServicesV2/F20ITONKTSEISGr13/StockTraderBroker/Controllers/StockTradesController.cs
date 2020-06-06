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
using StockTraderBroker.Data;
using StockTraderBroker.Models;

namespace StockTraderBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTradesController : ControllerBase
    {
        private readonly StockTraderBrokerContext _context;
        private readonly HttpClient PublicShareControlClient;
        //private readonly HttpClient TobinTaxerServiceClient;

        public StockTradesController(IHttpClientFactory clientFactory, StockTraderBrokerContext context)
        {
            PublicShareControlClient = clientFactory.CreateClient("psocclient");
            _context = context;
        }

        // GET: api/StockTrades
        [HttpGet]
        public async Task<List<StockInformation>> GetStockTrade()
        {
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var result = new List<StockInformation>();
            using (var response = await PublicShareControlClient.GetAsync($"api/StockInformationsController"))
            {

                result = JsonConvert.DeserializeObject<List<StockInformation>>(
                    await response.Content.ReadAsStringAsync()
                );
            }

            return result;
        }

        /*
        // GET: api/StockTrades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockTrade>> GetStockTrade(int id)
        {
            var stockTrade = await _context.StockTrade.FindAsync(id);

            if (stockTrade == null)
            {
                return NotFound();
            }

            return stockTrade;
        }
        
        // PUT: api/StockTrades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockTrade(int id, StockTrade stockTrade)
        {
            if (id != stockTrade.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockTrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockTradeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StockTrades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StockTrade>> PostStockTrade(StockTrade stockTrade)
        {
            _context.StockTrade.Add(stockTrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockTrade", new { id = stockTrade.Id }, stockTrade);
        }

        // DELETE: api/StockTrades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockTrade>> DeleteStockTrade(int id)
        {
            var stockTrade = await _context.StockTrade.FindAsync(id);
            if (stockTrade == null)
            {
                return NotFound();
            }

            _context.StockTrade.Remove(stockTrade);
            await _context.SaveChangesAsync();

            return stockTrade;
        }

        private bool StockTradeExists(int id)
        {
            return _context.StockTrade.Any(e => e.Id == id);
        }
        */
    }
}
