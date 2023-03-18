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
    public class ChatMessageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatMessageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChatMessage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMessage>>> GetChatMessages()
        {
          if (_context.ChatMessages == null)
          {
              return NotFound();
          }
            return await _context.ChatMessages.ToListAsync();
        }

        // GET: api/ChatMessage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMessage>> GetChatMessage(Guid id)
        {
          if (_context.ChatMessages == null)
          {
              return NotFound();
          }
            var chatMessage = await _context.ChatMessages.FindAsync(id);

            if (chatMessage == null)
            {
                return NotFound();
            }

            return chatMessage;
        }

        // PUT: api/ChatMessage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatMessage(Guid id, ChatMessage chatMessage)
        {
            if (id != chatMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMessageExists(id))
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

        // POST: api/ChatMessage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatMessage>> PostChatMessage(ChatMessage chatMessage)
        {
          if (_context.ChatMessages == null)
          {
              return Problem("Entity set 'AppDbContext.ChatMessages'  is null.");
          }
            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatMessage", new { id = chatMessage.Id }, chatMessage);
        }

        // DELETE: api/ChatMessage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatMessage(Guid id)
        {
            if (_context.ChatMessages == null)
            {
                return NotFound();
            }
            var chatMessage = await _context.ChatMessages.FindAsync(id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            _context.ChatMessages.Remove(chatMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatMessageExists(Guid id)
        {
            return (_context.ChatMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
