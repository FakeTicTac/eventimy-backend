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
    public class PollOptionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PollOptionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PollOption
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollOption>>> GetPollOptions()
        {
          if (_context.PollOptions == null)
          {
              return NotFound();
          }
            return await _context.PollOptions.ToListAsync();
        }

        // GET: api/PollOption/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollOption>> GetPollOption(Guid id)
        {
          if (_context.PollOptions == null)
          {
              return NotFound();
          }
            var pollOption = await _context.PollOptions.FindAsync(id);

            if (pollOption == null)
            {
                return NotFound();
            }

            return pollOption;
        }

        // PUT: api/PollOption/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollOption(Guid id, PollOption pollOption)
        {
            if (id != pollOption.Id)
            {
                return BadRequest();
            }

            _context.Entry(pollOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollOptionExists(id))
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

        // POST: api/PollOption
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PollOption>> PostPollOption(PollOption pollOption)
        {
          if (_context.PollOptions == null)
          {
              return Problem("Entity set 'AppDbContext.PollOptions'  is null.");
          }
            _context.PollOptions.Add(pollOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollOption", new { id = pollOption.Id }, pollOption);
        }

        // DELETE: api/PollOption/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePollOption(Guid id)
        {
            if (_context.PollOptions == null)
            {
                return NotFound();
            }
            var pollOption = await _context.PollOptions.FindAsync(id);
            if (pollOption == null)
            {
                return NotFound();
            }

            _context.PollOptions.Remove(pollOption);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PollOptionExists(Guid id)
        {
            return (_context.PollOptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
