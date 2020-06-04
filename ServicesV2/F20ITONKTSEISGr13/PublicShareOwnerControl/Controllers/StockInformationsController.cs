using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicShareOwnerControl.Data;
using PublicShareOwnerControl.Models;

namespace PublicShareOwnerControl.Controllers
{
    [Route("api/StockInformationsController")]
    [ApiController]
    public class StockInformationsController : ControllerBase
    {
        private readonly PublicShareOwnerControlContext _context;

        public StockInformationsController(PublicShareOwnerControlContext context)
        {
            _context = context;
        }

        // GET: api/StockInformations
        [HttpGet]
        public async Task<List<StockInformation>> GetStockInformation()
        {
            return await _context.StockInformation.ToListAsync();
        }

        // GET: api/StockInformations/5
        [HttpGet("{id}")]
        public async Task<StockInformation> GetStockInformation(int id)
        {
            return await _context.StockInformation.FindAsync(id);
        }

        // PUT: api/StockInformations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockInformation(int id, StockInformation stockInformation)
        {
            if (id != stockInformation.StockId)
            {
                return BadRequest();
            }

            _context.Entry(stockInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockInformationExists(id))
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

        // POST: api/StockInformations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StockInformation>> PostStockInformation(StockInformation stockInformation)
        {
            _context.StockInformation.Add(stockInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockInformation", new { id = stockInformation.StockId }, stockInformation);
        }

        // DELETE: api/StockInformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockInformation>> DeleteStockInformation(int id)
        {
            var stockInformation = await _context.StockInformation.FindAsync(id);
            if (stockInformation == null)
            {
                return NotFound();
            }

            _context.StockInformation.Remove(stockInformation);
            await _context.SaveChangesAsync();

            return stockInformation;
        }

        private bool StockInformationExists(int id)
        {
            return _context.StockInformation.Any(e => e.StockId == id);
        }
    }
}
