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
    public class ChatParticipantController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatParticipantController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChatParticipant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatParticipant>>> GetChatParticipants()
        {
          if (_context.ChatParticipants == null)
          {
              return NotFound();
          }
            return await _context.ChatParticipants.ToListAsync();
        }

        // GET: api/ChatParticipant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatParticipant>> GetChatParticipant(Guid id)
        {
          if (_context.ChatParticipants == null)
          {
              return NotFound();
          }
            var chatParticipant = await _context.ChatParticipants.FindAsync(id);

            if (chatParticipant == null)
            {
                return NotFound();
            }

            return chatParticipant;
        }

        // PUT: api/ChatParticipant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatParticipant(Guid id, ChatParticipant chatParticipant)
        {
            if (id != chatParticipant.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatParticipant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatParticipantExists(id))
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

        // POST: api/ChatParticipant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatParticipant>> PostChatParticipant(ChatParticipant chatParticipant)
        {
          if (_context.ChatParticipants == null)
          {
              return Problem("Entity set 'AppDbContext.ChatParticipants'  is null.");
          }
            _context.ChatParticipants.Add(chatParticipant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatParticipant", new { id = chatParticipant.Id }, chatParticipant);
        }

        // DELETE: api/ChatParticipant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatParticipant(Guid id)
        {
            if (_context.ChatParticipants == null)
            {
                return NotFound();
            }
            var chatParticipant = await _context.ChatParticipants.FindAsync(id);
            if (chatParticipant == null)
            {
                return NotFound();
            }

            _context.ChatParticipants.Remove(chatParticipant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatParticipantExists(Guid id)
        {
            return (_context.ChatParticipants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
