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
    public class WeekliesController : ControllerBase
    {
        private readonly DataContext _context;

        public WeekliesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Weeklies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weekly>>> GetWeeklySpecials()
        {
          if (_context.WeeklySpecials == null)
          {
              return NotFound();
          }
            return await _context.WeeklySpecials.ToListAsync();
        }

        // GET: api/Weeklies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weekly>> GetWeekly(int id)
        {
          if (_context.WeeklySpecials == null)
          {
              return NotFound();
          }
            var weekly = await _context.WeeklySpecials.FindAsync(id);

            if (weekly == null)
            {
                return NotFound();
            }

            return weekly;
        }

        // PUT: api/Weeklies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeekly(int id, Weekly weekly)
        {
            if (id != weekly.Id)
            {
                return BadRequest();
            }

            _context.Entry(weekly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeeklyExists(id))
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

        // POST: api/Weeklies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weekly>> PostWeekly(Weekly weekly)
        {
          if (_context.WeeklySpecials == null)
          {
              return Problem("Entity set 'DataContext.WeeklySpecials'  is null.");
          }
            _context.WeeklySpecials.Add(weekly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeekly", new { id = weekly.Id }, weekly);
        }

        // DELETE: api/Weeklies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeekly(int id)
        {
            if (_context.WeeklySpecials == null)
            {
                return NotFound();
            }
            var weekly = await _context.WeeklySpecials.FindAsync(id);
            if (weekly == null)
            {
                return NotFound();
            }

            _context.WeeklySpecials.Remove(weekly);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeeklyExists(int id)
        {
            return (_context.WeeklySpecials?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
