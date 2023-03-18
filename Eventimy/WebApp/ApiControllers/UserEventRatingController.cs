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
    public class UserEventRatingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserEventRatingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserEventRating
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEventRating>>> GetUserEventRatings()
        {
          if (_context.UserEventRatings == null)
          {
              return NotFound();
          }
            return await _context.UserEventRatings.ToListAsync();
        }

        // GET: api/UserEventRating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEventRating>> GetUserEventRating(Guid id)
        {
          if (_context.UserEventRatings == null)
          {
              return NotFound();
          }
            var userEventRating = await _context.UserEventRatings.FindAsync(id);

            if (userEventRating == null)
            {
                return NotFound();
            }

            return userEventRating;
        }

        // PUT: api/UserEventRating/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEventRating(Guid id, UserEventRating userEventRating)
        {
            if (id != userEventRating.Id)
            {
                return BadRequest();
            }

            _context.Entry(userEventRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEventRatingExists(id))
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

        // POST: api/UserEventRating
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserEventRating>> PostUserEventRating(UserEventRating userEventRating)
        {
          if (_context.UserEventRatings == null)
          {
              return Problem("Entity set 'AppDbContext.UserEventRatings'  is null.");
          }
            _context.UserEventRatings.Add(userEventRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserEventRating", new { id = userEventRating.Id }, userEventRating);
        }

        // DELETE: api/UserEventRating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserEventRating(Guid id)
        {
            if (_context.UserEventRatings == null)
            {
                return NotFound();
            }
            var userEventRating = await _context.UserEventRatings.FindAsync(id);
            if (userEventRating == null)
            {
                return NotFound();
            }

            _context.UserEventRatings.Remove(userEventRating);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserEventRatingExists(Guid id)
        {
            return (_context.UserEventRatings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
