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
    public class ChatMediaFileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatMediaFileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChatMediaFile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMediaFile>>> GetChatMediaFiles()
        {
          if (_context.ChatMediaFiles == null)
          {
              return NotFound();
          }
            return await _context.ChatMediaFiles.ToListAsync();
        }

        // GET: api/ChatMediaFile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMediaFile>> GetChatMediaFile(Guid id)
        {
          if (_context.ChatMediaFiles == null)
          {
              return NotFound();
          }
            var chatMediaFile = await _context.ChatMediaFiles.FindAsync(id);

            if (chatMediaFile == null)
            {
                return NotFound();
            }

            return chatMediaFile;
        }

        // PUT: api/ChatMediaFile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatMediaFile(Guid id, ChatMediaFile chatMediaFile)
        {
            if (id != chatMediaFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(chatMediaFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMediaFileExists(id))
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

        // POST: api/ChatMediaFile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatMediaFile>> PostChatMediaFile(ChatMediaFile chatMediaFile)
        {
          if (_context.ChatMediaFiles == null)
          {
              return Problem("Entity set 'AppDbContext.ChatMediaFiles'  is null.");
          }
            _context.ChatMediaFiles.Add(chatMediaFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatMediaFile", new { id = chatMediaFile.Id }, chatMediaFile);
        }

        // DELETE: api/ChatMediaFile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatMediaFile(Guid id)
        {
            if (_context.ChatMediaFiles == null)
            {
                return NotFound();
            }
            var chatMediaFile = await _context.ChatMediaFiles.FindAsync(id);
            if (chatMediaFile == null)
            {
                return NotFound();
            }

            _context.ChatMediaFiles.Remove(chatMediaFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatMediaFileExists(Guid id)
        {
            return (_context.ChatMediaFiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
