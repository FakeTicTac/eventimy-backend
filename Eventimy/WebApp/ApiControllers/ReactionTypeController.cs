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
    public class ReactionTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReactionTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReactionType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReactionType>>> GetReactionTypes()
        {
          if (_context.ReactionTypes == null)
          {
              return NotFound();
          }
            return await _context.ReactionTypes.ToListAsync();
        }

        // GET: api/ReactionType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReactionType>> GetReactionType(Guid id)
        {
          if (_context.ReactionTypes == null)
          {
              return NotFound();
          }
            var reactionType = await _context.ReactionTypes.FindAsync(id);

            if (reactionType == null)
            {
                return NotFound();
            }

            return reactionType;
        }

        // PUT: api/ReactionType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReactionType(Guid id, ReactionType reactionType)
        {
            if (id != reactionType.Id)
            {
                return BadRequest();
            }

            _context.Entry(reactionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactionTypeExists(id))
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

        // POST: api/ReactionType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReactionType>> PostReactionType(ReactionType reactionType)
        {
          if (_context.ReactionTypes == null)
          {
              return Problem("Entity set 'AppDbContext.ReactionTypes'  is null.");
          }
            _context.ReactionTypes.Add(reactionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReactionType", new { id = reactionType.Id }, reactionType);
        }

        // DELETE: api/ReactionType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReactionType(Guid id)
        {
            if (_context.ReactionTypes == null)
            {
                return NotFound();
            }
            var reactionType = await _context.ReactionTypes.FindAsync(id);
            if (reactionType == null)
            {
                return NotFound();
            }

            _context.ReactionTypes.Remove(reactionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReactionTypeExists(Guid id)
        {
            return (_context.ReactionTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
