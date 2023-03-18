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
    public class ChatPollController : Controller
    {
        private readonly AppDbContext _context;

        public ChatPollController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChatPoll
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ChatPolls.Include(c => c.Chat).Include(c => c.ChatParticipant);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/ChatPoll/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ChatPolls == null)
            {
                return NotFound();
            }

            var chatPoll = await _context.ChatPolls
                .Include(c => c.Chat)
                .Include(c => c.ChatParticipant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatPoll == null)
            {
                return NotFound();
            }

            return View(chatPoll);
        }

        // GET: Admin/ChatPoll/Create
        public IActionResult Create()
        {
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id");
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id");
            return View();
        }

        // POST: Admin/ChatPoll/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,IsAnonymous,IsMultipleChoice,CanChangeVote,IsLimitedTime,EndTime,ChatId,ChatParticipantId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ChatPoll chatPoll)
        {
            if (ModelState.IsValid)
            {
                chatPoll.Id = Guid.NewGuid();
                _context.Add(chatPoll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatPoll.ChatId);
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", chatPoll.ChatParticipantId);
            return View(chatPoll);
        }

        // GET: Admin/ChatPoll/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ChatPolls == null)
            {
                return NotFound();
            }

            var chatPoll = await _context.ChatPolls.FindAsync(id);
            if (chatPoll == null)
            {
                return NotFound();
            }
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatPoll.ChatId);
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", chatPoll.ChatParticipantId);
            return View(chatPoll);
        }

        // POST: Admin/ChatPoll/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,IsAnonymous,IsMultipleChoice,CanChangeVote,IsLimitedTime,EndTime,ChatId,ChatParticipantId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ChatPoll chatPoll)
        {
            if (id != chatPoll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatPoll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatPollExists(chatPoll.Id))
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
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatPoll.ChatId);
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", chatPoll.ChatParticipantId);
            return View(chatPoll);
        }

        // GET: Admin/ChatPoll/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ChatPolls == null)
            {
                return NotFound();
            }

            var chatPoll = await _context.ChatPolls
                .Include(c => c.Chat)
                .Include(c => c.ChatParticipant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatPoll == null)
            {
                return NotFound();
            }

            return View(chatPoll);
        }

        // POST: Admin/ChatPoll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ChatPolls == null)
            {
                return Problem("Entity set 'AppDbContext.ChatPolls'  is null.");
            }
            var chatPoll = await _context.ChatPolls.FindAsync(id);
            if (chatPoll != null)
            {
                _context.ChatPolls.Remove(chatPoll);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatPollExists(Guid id)
        {
          return (_context.ChatPolls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
