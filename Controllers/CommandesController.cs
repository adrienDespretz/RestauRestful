using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauRestful.Models;

namespace RestauRestful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly CommandesContext _context;

        public CommandesController(CommandesContext context)
        {
            _context = context;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commandes>>> GetCommandes()
        {
          if (_context.Commandes == null)
          {
              return NotFound();
          }
            return await _context.Commandes.ToListAsync();
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commandes>> GetCommandes(long id)
        {
          if (_context.Commandes == null)
          {
              return NotFound();
          }
            var commandes = await _context.Commandes.FindAsync(id);

            if (commandes == null)
            {
                return NotFound();
            }

            return commandes;
        }

        // PUT: api/Commandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommandes(long id, Commandes commandes)
        {
            if (id != commandes.id)
            {
                return BadRequest();
            }

            _context.Entry(commandes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandesExists(id))
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

        // POST: api/Commandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commandes>> PostCommandes(Commandes commandes)
        {
          if (_context.Commandes == null)
          {
              return Problem("Entity set 'CommandesContext.Commandes'  is null.");
          }
            _context.Commandes.Add(commandes);
            await _context.SaveChangesAsync();

           // return CreatedAtAction("GetCommandes", new { id = commandes.id }, commandes);
           return CreatedAtAction(nameof(GetCommandes), new { id = commandes.id }, commandes);
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommandes(long id)
        {
            if (_context.Commandes == null)
            {
                return NotFound();
            }
            var commandes = await _context.Commandes.FindAsync(id);
            if (commandes == null)
            {
                return NotFound();
            }

            _context.Commandes.Remove(commandes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandesExists(long id)
        {
            return (_context.Commandes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
