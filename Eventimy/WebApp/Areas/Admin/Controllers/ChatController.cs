using App.DAL.EF;
using App.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChatController : Controller
    {
        private readonly AppDbContext _context;

        public ChatController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Chat
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Chats.Include(c => c.AppUser).Include(c => c.Event);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Chat/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .Include(c => c.AppUser)
                .Include(c => c.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // GET: Admin/Chat/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            return View();
        }

        // POST: Admin/Chat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ThumbNailImage,EventId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] Chat chat)
        {
            if (ModelState.IsValid)
            {
                chat.Id = Guid.NewGuid();
                _context.Add(chat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", chat.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", chat.EventId);
            return View(chat);
        }

        // GET: Admin/Chat/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", chat.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", chat.EventId);
            return View(chat);
        }

        // POST: Admin/Chat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,ThumbNailImage,EventId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] Chat chat)
        {
            if (id != chat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(chat.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", chat.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", chat.EventId);
            return View(chat);
        }

        // GET: Admin/Chat/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .Include(c => c.AppUser)
                .Include(c => c.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // POST: Admin/Chat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Chats == null)
            {
                return Problem("Entity set 'AppDbContext.Chats'  is null.");
            }
            var chat = await _context.Chats.FindAsync(id);
            if (chat != null)
            {
                _context.Chats.Remove(chat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatExists(Guid id)
        {
          return (_context.Chats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
