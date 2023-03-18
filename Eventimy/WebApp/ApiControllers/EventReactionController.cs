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
    public class EventReactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventReactionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventReaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventReaction>>> GetEventReactions()
        {
          if (_context.EventReactions == null)
          {
              return NotFound();
          }
            return await _context.EventReactions.ToListAsync();
        }

        // GET: api/EventReaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventReaction>> GetEventReaction(Guid id)
        {
          if (_context.EventReactions == null)
          {
              return NotFound();
          }
            var eventReaction = await _context.EventReactions.FindAsync(id);

            if (eventReaction == null)
            {
                return NotFound();
            }

            return eventReaction;
        }

        // PUT: api/EventReaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventReaction(Guid id, EventReaction eventReaction)
        {
            if (id != eventReaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventReaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventReactionExists(id))
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

        // POST: api/EventReaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventReaction>> PostEventReaction(EventReaction eventReaction)
        {
          if (_context.EventReactions == null)
          {
              return Problem("Entity set 'AppDbContext.EventReactions'  is null.");
          }
            _context.EventReactions.Add(eventReaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventReaction", new { id = eventReaction.Id }, eventReaction);
        }

        // DELETE: api/EventReaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventReaction(Guid id)
        {
            if (_context.EventReactions == null)
            {
                return NotFound();
            }
            var eventReaction = await _context.EventReactions.FindAsync(id);
            if (eventReaction == null)
            {
                return NotFound();
            }

            _context.EventReactions.Remove(eventReaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventReactionExists(Guid id)
        {
            return (_context.EventReactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
