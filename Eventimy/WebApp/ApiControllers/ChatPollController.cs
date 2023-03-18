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
    public class ChatPollController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatPollController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChatPoll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatPoll>>> GetChatPolls()
        {
          if (_context.ChatPolls == null)
          {
              return NotFound();
          }
            return await _context.ChatPolls.ToListAsync();
        }

        // GET: api/ChatPoll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatPoll>> GetChatPoll(Guid id)
        {
          if (_context.ChatPolls == null)
          {
              return NotFound();
          }
            var chatPoll = await _context.ChatPolls.FindAsync(id);

            if (chatPoll == null)
            {
                return NotFound();
            }

            return chatPoll;
        }

        // PUT: api/ChatPoll/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatPoll(Guid id, ChatPoll chatPoll)
        {
            if (id != chatPoll.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatPoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatPollExists(id))
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

        // POST: api/ChatPoll
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatPoll>> PostChatPoll(ChatPoll chatPoll)
        {
          if (_context.ChatPolls == null)
          {
              return Problem("Entity set 'AppDbContext.ChatPolls'  is null.");
          }
            _context.ChatPolls.Add(chatPoll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatPoll", new { id = chatPoll.Id }, chatPoll);
        }

        // DELETE: api/ChatPoll/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatPoll(Guid id)
        {
            if (_context.ChatPolls == null)
            {
                return NotFound();
            }
            var chatPoll = await _context.ChatPolls.FindAsync(id);
            if (chatPoll == null)
            {
                return NotFound();
            }

            _context.ChatPolls.Remove(chatPoll);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatPollExists(Guid id)
        {
            return (_context.ChatPolls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
