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
    public class ChatMediaFileController : Controller
    {
        private readonly AppDbContext _context;

        public ChatMediaFileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChatMediaFile
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ChatMediaFiles.Include(c => c.Chat).Include(c => c.ChatMessage).Include(c => c.MediaFileType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/ChatMediaFile/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ChatMediaFiles == null)
            {
                return NotFound();
            }

            var chatMediaFile = await _context.ChatMediaFiles
                .Include(c => c.Chat)
                .Include(c => c.ChatMessage)
                .Include(c => c.MediaFileType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatMediaFile == null)
            {
                return NotFound();
            }

            return View(chatMediaFile);
        }

        // GET: Admin/ChatMediaFile/Create
        public IActionResult Create()
        {
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id");
            ViewData["ChatMessageId"] = new SelectList(_context.ChatMessages, "Id", "Id");
            ViewData["MediaFileTypeId"] = new SelectList(_context.MediaFileTypes, "Id", "Id");
            return View();
        }

        // POST: Admin/ChatMediaFile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediaFile,ChatMessageId,ChatId,MediaFileTypeId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ChatMediaFile chatMediaFile)
        {
            if (ModelState.IsValid)
            {
                chatMediaFile.Id = Guid.NewGuid();
                _context.Add(chatMediaFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatMediaFile.ChatId);
            ViewData["ChatMessageId"] = new SelectList(_context.ChatMessages, "Id", "Id", chatMediaFile.ChatMessageId);
            ViewData["MediaFileTypeId"] = new SelectList(_context.MediaFileTypes, "Id", "Id", chatMediaFile.MediaFileTypeId);
            return View(chatMediaFile);
        }

        // GET: Admin/ChatMediaFile/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ChatMediaFiles == null)
            {
                return NotFound();
            }

            var chatMediaFile = await _context.ChatMediaFiles.FindAsync(id);
            if (chatMediaFile == null)
            {
                return NotFound();
            }
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatMediaFile.ChatId);
            ViewData["ChatMessageId"] = new SelectList(_context.ChatMessages, "Id", "Id", chatMediaFile.ChatMessageId);
            ViewData["MediaFileTypeId"] = new SelectList(_context.MediaFileTypes, "Id", "Id", chatMediaFile.MediaFileTypeId);
            return View(chatMediaFile);
        }

        // POST: Admin/ChatMediaFile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MediaFile,ChatMessageId,ChatId,MediaFileTypeId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ChatMediaFile chatMediaFile)
        {
            if (id != chatMediaFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatMediaFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatMediaFileExists(chatMediaFile.Id))
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
            ViewData["ChatId"] = new SelectList(_context.Chats, "Id", "Id", chatMediaFile.ChatId);
            ViewData["ChatMessageId"] = new SelectList(_context.ChatMessages, "Id", "Id", chatMediaFile.ChatMessageId);
            ViewData["MediaFileTypeId"] = new SelectList(_context.MediaFileTypes, "Id", "Id", chatMediaFile.MediaFileTypeId);
            return View(chatMediaFile);
        }

        // GET: Admin/ChatMediaFile/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ChatMediaFiles == null)
            {
                return NotFound();
            }

            var chatMediaFile = await _context.ChatMediaFiles
                .Include(c => c.Chat)
                .Include(c => c.ChatMessage)
                .Include(c => c.MediaFileType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatMediaFile == null)
            {
                return NotFound();
            }

            return View(chatMediaFile);
        }

        // POST: Admin/ChatMediaFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ChatMediaFiles == null)
            {
                return Problem("Entity set 'AppDbContext.ChatMediaFiles'  is null.");
            }
            var chatMediaFile = await _context.ChatMediaFiles.FindAsync(id);
            if (chatMediaFile != null)
            {
                _context.ChatMediaFiles.Remove(chatMediaFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatMediaFileExists(Guid id)
        {
          return (_context.ChatMediaFiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
