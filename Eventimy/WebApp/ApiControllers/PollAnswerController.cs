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
    public class PollAnswerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PollAnswerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PollAnswer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollAnswer>>> GetPollAnswers()
        {
          if (_context.PollAnswers == null)
          {
              return NotFound();
          }
            return await _context.PollAnswers.ToListAsync();
        }

        // GET: api/PollAnswer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollAnswer>> GetPollAnswer(Guid id)
        {
          if (_context.PollAnswers == null)
          {
              return NotFound();
          }
            var pollAnswer = await _context.PollAnswers.FindAsync(id);

            if (pollAnswer == null)
            {
                return NotFound();
            }

            return pollAnswer;
        }

        // PUT: api/PollAnswer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollAnswer(Guid id, PollAnswer pollAnswer)
        {
            if (id != pollAnswer.Id)
            {
                return BadRequest();
            }

            _context.Entry(pollAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollAnswerExists(id))
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

        // POST: api/PollAnswer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PollAnswer>> PostPollAnswer(PollAnswer pollAnswer)
        {
          if (_context.PollAnswers == null)
          {
              return Problem("Entity set 'AppDbContext.PollAnswers'  is null.");
          }
            _context.PollAnswers.Add(pollAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollAnswer", new { id = pollAnswer.Id }, pollAnswer);
        }

        // DELETE: api/PollAnswer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePollAnswer(Guid id)
        {
            if (_context.PollAnswers == null)
            {
                return NotFound();
            }
            var pollAnswer = await _context.PollAnswers.FindAsync(id);
            if (pollAnswer == null)
            {
                return NotFound();
            }

            _context.PollAnswers.Remove(pollAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PollAnswerExists(Guid id)
        {
            return (_context.PollAnswers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
