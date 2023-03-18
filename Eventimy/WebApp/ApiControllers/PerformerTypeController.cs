using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformerTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PerformerTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PerformerType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformerType>>> GetPerformerTypes()
        {
          if (_context.PerformerTypes == null)
          {
              return NotFound();
          }
            return await _context.PerformerTypes.ToListAsync();
        }

        // GET: api/PerformerType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PerformerType>> GetPerformerType(Guid id)
        {
          if (_context.PerformerTypes == null)
          {
              return NotFound();
          }
            var performerType = await _context.PerformerTypes.FindAsync(id);

            if (performerType == null)
            {
                return NotFound();
            }

            return performerType;
        }

        // PUT: api/PerformerType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerformerType(Guid id, PerformerType performerType)
        {
            if (id != performerType.Id)
            {
                return BadRequest();
            }

            _context.Entry(performerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformerTypeExists(id))
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

        // POST: api/PerformerType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PerformerType>> PostPerformerType(PerformerType performerType)
        {
          if (_context.PerformerTypes == null)
          {
              return Problem("Entity set 'AppDbContext.PerformerTypes'  is null.");
          }
            _context.PerformerTypes.Add(performerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerformerType", new { id = performerType.Id }, performerType);
        }

        // DELETE: api/PerformerType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformerType(Guid id)
        {
            if (_context.PerformerTypes == null)
            {
                return NotFound();
            }
            var performerType = await _context.PerformerTypes.FindAsync(id);
            if (performerType == null)
            {
                return NotFound();
            }

            _context.PerformerTypes.Remove(performerType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerformerTypeExists(Guid id)
        {
            return (_context.PerformerTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
