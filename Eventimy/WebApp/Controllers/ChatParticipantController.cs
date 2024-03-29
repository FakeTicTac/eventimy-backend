using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.Controllers
{
    public class ChatParticipantController : Controller
    {
        private readonly AppDbContext _context;

        public ChatParticipantController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ChatParticipant
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ChatParticipants.Include(c => c.AppUser).Include(c => c.Chat);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ChatParticipant/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ChatParticipants == null)
            {
                return NotFound();
            }

            var chatParticipant = await _context.ChatParticipants
                .Include(c => c.AppUser)
                .Include(c => c.Chat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatParticipant == null)
            {
                return NotFound();
            }

            return View(chatParticipant);
        }

        // GET: ChatParticipant/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id");
            return View();
        }

        // POST: ChatParticipant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nickname,ChatId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ChatParticipant chatParticipant)
        {
            if (ModelState.IsValid)
            {
                chatParticipant.Id = Guid.NewGuid();
                _context.Add(chatParticipant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", chatParticipant.AppUserId);
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatParticipant.ChatId);
            return View(chatParticipant);
        }

        // GET: ChatParticipant/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ChatParticipants == null)
            {
                return NotFound();
            }

            var chatParticipant = await _context.ChatParticipants.FindAsync(id);
            if (chatParticipant == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", chatParticipant.AppUserId);
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatParticipant.ChatId);
            return View(chatParticipant);
        }

        // POST: ChatParticipant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nickname,ChatId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ChatParticipant chatParticipant)
        {
            if (id != chatParticipant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatParticipant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatParticipantExists(chatParticipant.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", chatParticipant.AppUserId);
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatParticipant.ChatId);
            return View(chatParticipant);
        }

        // GET: ChatParticipant/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ChatParticipants == null)
            {
                return NotFound();
            }

            var chatParticipant = await _context.ChatParticipants
                .Include(c => c.AppUser)
                .Include(c => c.Chat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatParticipant == null)
            {
                return NotFound();
            }

            return View(chatParticipant);
        }

        // POST: ChatParticipant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ChatParticipants == null)
            {
                return Problem("Entity set 'AppDbContext.ChatParticipants'  is null.");
            }
            var chatParticipant = await _context.ChatParticipants.FindAsync(id);
            if (chatParticipant != null)
            {
                _context.ChatParticipants.Remove(chatParticipant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatParticipantExists(Guid id)
        {
          return (_context.ChatParticipants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
