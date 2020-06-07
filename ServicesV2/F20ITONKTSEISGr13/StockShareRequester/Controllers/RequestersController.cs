using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockShareRequester.Data;
using StockShareRequester.Models;

namespace StockShareRequester.Controllers
{
    [Route("api/StockShareRequesterController")]
    [ApiController]
    public class RequestersController : ControllerBase
    {
        private readonly StockShareRequesterContext _context;

        public RequestersController(StockShareRequesterContext context)
        {
            _context = context;
        }

        // GET: api/Requesters
        [HttpGet]
        public async Task<List<Requester>> GetRequester()
        {
            return await _context.Requester.ToListAsync();
        }

        // GET: api/Requesters/5
        [HttpGet("{id}")]
        public async Task<Requester> GetRequester(int id)
        {
            return await _context.Requester.FindAsync(id);
        }

        // PUT: api/Requesters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequester(int id, Requester requester)
        {
            if (id != requester.OwnerId)
            {
                return BadRequest();
            }

            _context.Entry(requester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequesterExists(id))
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

        // POST: api/Requesters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Requester>> PostRequester(Requester requester)
        {
            _context.Requester.Add(requester);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequester", new { id = requester.OwnerId }, requester);
        }

        // DELETE: api/Requesters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Requester>> DeleteRequester(int id)
        {
            var requester = await _context.Requester.FindAsync(id);
            if (requester == null)
            {
                return NotFound();
            }

            _context.Requester.Remove(requester);
            await _context.SaveChangesAsync();

            return requester;
        }

        private bool RequesterExists(int id)
        {
            return _context.Requester.Any(e => e.OwnerId == id);
        }
    }
}
