using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockTransactionItems.Data;
using StockTransactionItems.Models;
using StockTransactionItems.Repositories;

namespace StockTransactionItems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private IStockRepository _stockRepository;

        public StocksController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        // GET: api/Stocks
        [HttpGet]
        public IEnumerable<Stock> GetAllStocks()
        {
            return _stockRepository.GetListOfStocks();
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public Stock GetStock(int id)
        {
            return _stockRepository.GetStockById(id);
        }

        // POST: api/Stocks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromBody]Stock stock)
        {
            _stockRepository.AddStock(stock);
            _stockRepository.Save();
            return Ok(stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public void DeleteStock(int id)
        {
            _stockRepository.RemoveStock(id);
            _stockRepository.Save();
        }
    }
}
