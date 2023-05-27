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
    public class MonthliesController : ControllerBase
    {
        private readonly DataContext _context;

        public MonthliesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Monthlies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monthly>>> GetMonthlyEvents()
        {
          if (_context.MonthlyEvents == null)
          {
              return NotFound();
          }
            return await _context.MonthlyEvents.ToListAsync();
        }

        // GET: api/Monthlies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monthly>> GetMonthly(int id)
        {
          if (_context.MonthlyEvents == null)
          {
              return NotFound();
          }
            var monthly = await _context.MonthlyEvents.FindAsync(id);

            if (monthly == null)
            {
                return NotFound();
            }

            return monthly;
        }

        // PUT: api/Monthlies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthly(int id, Monthly monthly)
        {
            if (id != monthly.Id)
            {
                return BadRequest();
            }

            _context.Entry(monthly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyExists(id))
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

        // POST: api/Monthlies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Monthly>> PostMonthly(Monthly monthly)
        {
          if (_context.MonthlyEvents == null)
          {
              return Problem("Entity set 'DataContext.MonthlyEvents'  is null.");
          }
            _context.MonthlyEvents.Add(monthly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthly", new { id = monthly.Id }, monthly);
        }

        // DELETE: api/Monthlies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthly(int id)
        {
            if (_context.MonthlyEvents == null)
            {
                return NotFound();
            }
            var monthly = await _context.MonthlyEvents.FindAsync(id);
            if (monthly == null)
            {
                return NotFound();
            }

            _context.MonthlyEvents.Remove(monthly);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonthlyExists(int id)
        {
            return (_context.MonthlyEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
