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
    public class UserInEventController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserInEventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInEvent>>> GetUserInEvents()
        {
          if (_context.UserInEvents == null)
          {
              return NotFound();
          }
            return await _context.UserInEvents.ToListAsync();
        }

        // GET: api/UserInEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInEvent>> GetUserInEvent(Guid id)
        {
          if (_context.UserInEvents == null)
          {
              return NotFound();
          }
            var userInEvent = await _context.UserInEvents.FindAsync(id);

            if (userInEvent == null)
            {
                return NotFound();
            }

            return userInEvent;
        }

        // PUT: api/UserInEvent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInEvent(Guid id, UserInEvent userInEvent)
        {
            if (id != userInEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInEventExists(id))
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

        // POST: api/UserInEvent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInEvent>> PostUserInEvent(UserInEvent userInEvent)
        {
          if (_context.UserInEvents == null)
          {
              return Problem("Entity set 'AppDbContext.UserInEvents'  is null.");
          }
            _context.UserInEvents.Add(userInEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInEvent", new { id = userInEvent.Id }, userInEvent);
        }

        // DELETE: api/UserInEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInEvent(Guid id)
        {
            if (_context.UserInEvents == null)
            {
                return NotFound();
            }
            var userInEvent = await _context.UserInEvents.FindAsync(id);
            if (userInEvent == null)
            {
                return NotFound();
            }

            _context.UserInEvents.Remove(userInEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInEventExists(Guid id)
        {
            return (_context.UserInEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
