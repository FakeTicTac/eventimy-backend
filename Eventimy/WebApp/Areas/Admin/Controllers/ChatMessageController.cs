using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChatMessageController : Controller
    {
        private readonly AppDbContext _context;

        public ChatMessageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChatMessage
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ChatMessages.Include(c => c.Chat).Include(c => c.ChatParticipant);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/ChatMessage/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ChatMessages == null)
            {
                return NotFound();
            }

            var chatMessage = await _context.ChatMessages
                .Include(c => c.Chat)
                .Include(c => c.ChatParticipant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            return View(chatMessage);
        }

        // GET: Admin/ChatMessage/Create
        public IActionResult Create()
        {
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id");
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id");
            return View();
        }

        // POST: Admin/ChatMessage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,IsPinned,ChatId,ChatParticipantId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ChatMessage chatMessage)
        {
            if (ModelState.IsValid)
            {
                chatMessage.Id = Guid.NewGuid();
                _context.Add(chatMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatMessage.ChatId);
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", chatMessage.ChatParticipantId);
            return View(chatMessage);
        }

        // GET: Admin/ChatMessage/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ChatMessages == null)
            {
                return NotFound();
            }

            var chatMessage = await _context.ChatMessages.FindAsync(id);
            if (chatMessage == null)
            {
                return NotFound();
            }
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatMessage.ChatId);
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", chatMessage.ChatParticipantId);
            return View(chatMessage);
        }

        // POST: Admin/ChatMessage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Content,IsPinned,ChatId,ChatParticipantId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ChatMessage chatMessage)
        {
            if (id != chatMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatMessageExists(chatMessage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatMessage.ChatId);
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", chatMessage.ChatParticipantId);
            return View(chatMessage);
        }

        // GET: Admin/ChatMessage/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ChatMessages == null)
            {
                return NotFound();
            }

            var chatMessage = await _context.ChatMessages
                .Include(c => c.Chat)
                .Include(c => c.ChatParticipant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            return View(chatMessage);
        }

        // POST: Admin/ChatMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ChatMessages == null)
            {
                return Problem("Entity set 'AppDbContext.ChatMessages'  is null.");
            }
            var chatMessage = await _context.ChatMessages.FindAsync(id);
            if (chatMessage != null)
            {
                _context.ChatMessages.Remove(chatMessage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatMessageExists(Guid id)
        {
          return (_context.ChatMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
