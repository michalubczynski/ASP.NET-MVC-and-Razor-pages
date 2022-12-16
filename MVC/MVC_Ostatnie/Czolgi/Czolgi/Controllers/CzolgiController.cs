using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Czolgi.Models;

namespace Czolgi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CzolgiController : ControllerBase
    {
        private readonly DbArmia _context;

        public CzolgiController(DbArmia context)
        {
            _context = context;
        }

        // GET: api/Czolgi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Czolg>>> GetCzolgi()
        {
            return await _context.Czolgi.ToListAsync();
        }

        // GET: api/Czolgi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Czolg>> GetCzolg(int id)
        {
            var czolg = await _context.Czolgi.FindAsync(id);

            if (czolg == null)
            {
                return NotFound();
            }

            return czolg;
        }

        // PUT: api/Czolgi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCzolg(int id, Czolg czolg)
        {
            if (id != czolg.CzolgId)
            {
                return BadRequest();
            }

            _context.Entry(czolg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CzolgExists(id))
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

        // POST: api/Czolgi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("test")]
        public async Task<ActionResult<Czolg>> PostCzolg(Czolg czolg)
        {
            var czolg1 = new Czolg();
            czolg1.Kaliber = czolg.Kaliber;
            czolg1.Typ = czolg.Typ;
            czolg1.Masa = czolg.Masa;
             if(czolg == null)
            {
                return Ok();
            } 
             _context.Add(czolg1);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCzolg", new { id = czolg1.CzolgId }, czolg1);
        }

        // DELETE: api/Czolgi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCzolg(int id)
        {
            var czolg = await _context.Czolgi.FindAsync(id);
            if (czolg == null)
            {
                return NotFound();
            }

            _context.Czolgi.Remove(czolg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CzolgExists(int id)
        {
            return _context.Czolgi.Any(e => e.CzolgId == id);
        }
    }
}
