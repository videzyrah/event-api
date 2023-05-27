using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuesdayAlphaApi.Data;
using TuesdayAlphaApi.Models;

namespace TuesdayAlphaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneTimeEventsController : ControllerBase
    {
        private readonly DataContext _context;

        public OneTimeEventsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OneTimeEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OneTimeEvent>>> GetOneTimeEvents()
        {
          if (_context.OneTimeEvents == null)
          {
              return NotFound();
          }
            return await _context.OneTimeEvents.ToListAsync();
        }

        // GET: api/OneTimeEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OneTimeEvent>> GetOneTimeEvent(int id)
        {
          if (_context.OneTimeEvents == null)
          {
              return NotFound();
          }
            var oneTimeEvent = await _context.OneTimeEvents.FindAsync(id);

            if (oneTimeEvent == null)
            {
                return NotFound();
            }

            return oneTimeEvent;
        }

        // PUT: api/OneTimeEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOneTimeEvent(int id, OneTimeEvent oneTimeEvent)
        {
            if (id != oneTimeEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(oneTimeEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OneTimeEventExists(id))
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

        // POST: api/OneTimeEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OneTimeEvent>> PostOneTimeEvent(OneTimeEvent oneTimeEvent)
        {
          if (_context.OneTimeEvents == null)
          {
              return Problem("Entity set 'DataContext.OneTimeEvents'  is null.");
          }
            _context.OneTimeEvents.Add(oneTimeEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneTimeEvent", new { id = oneTimeEvent.Id }, oneTimeEvent);
        }

        // DELETE: api/OneTimeEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneTimeEvent(int id)
        {
            if (_context.OneTimeEvents == null)
            {
                return NotFound();
            }
            var oneTimeEvent = await _context.OneTimeEvents.FindAsync(id);
            if (oneTimeEvent == null)
            {
                return NotFound();
            }

            _context.OneTimeEvents.Remove(oneTimeEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OneTimeEventExists(int id)
        {
            return (_context.OneTimeEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
