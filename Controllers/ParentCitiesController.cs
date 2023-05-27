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
    public class ParentCitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public ParentCitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ParentCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentCity>>> GetParentCities()
        {
          if (_context.ParentCities == null)
          {
              return NotFound();
          }
            return await _context.ParentCities.ToListAsync();
        }

        // GET: api/ParentCities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParentCity>> GetParentCity(int id)
        {
          if (_context.ParentCities == null)
          {
              return NotFound();
          }
            var parentCity = await _context.ParentCities.FindAsync(id);

            if (parentCity == null)
            {
                return NotFound();
            }

            return parentCity;
        }

        // PUT: api/ParentCities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParentCity(int id, ParentCity parentCity)
        {
            if (id != parentCity.Id)
            {
                return BadRequest();
            }

            _context.Entry(parentCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentCityExists(id))
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

        // POST: api/ParentCities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParentCity>> PostParentCity(ParentCity parentCity)
        {
          if (_context.ParentCities == null)
          {
              return Problem("Entity set 'DataContext.ParentCities'  is null.");
          }
            _context.ParentCities.Add(parentCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParentCity", new { id = parentCity.Id }, parentCity);
        }

        // DELETE: api/ParentCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParentCity(int id)
        {
            if (_context.ParentCities == null)
            {
                return NotFound();
            }
            var parentCity = await _context.ParentCities.FindAsync(id);
            if (parentCity == null)
            {
                return NotFound();
            }

            _context.ParentCities.Remove(parentCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentCityExists(int id)
        {
            return (_context.ParentCities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
