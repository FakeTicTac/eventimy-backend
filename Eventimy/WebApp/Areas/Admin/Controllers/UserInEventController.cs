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
    public class UserInEventController : Controller
    {
        private readonly AppDbContext _context;

        public UserInEventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/UserInEvent
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserInEvents.Include(u => u.AppUser).Include(u => u.Event);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/UserInEvent/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.UserInEvents == null)
            {
                return NotFound();
            }

            var userInEvent = await _context.UserInEvents
                .Include(u => u.AppUser)
                .Include(u => u.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInEvent == null)
            {
                return NotFound();
            }

            return View(userInEvent);
        }

        // GET: Admin/UserInEvent/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            return View();
        }

        // POST: Admin/UserInEvent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] UserInEvent userInEvent)
        {
            if (ModelState.IsValid)
            {
                userInEvent.Id = Guid.NewGuid();
                _context.Add(userInEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userInEvent.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", userInEvent.EventId);
            return View(userInEvent);
        }

        // GET: Admin/UserInEvent/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.UserInEvents == null)
            {
                return NotFound();
            }

            var userInEvent = await _context.UserInEvents.FindAsync(id);
            if (userInEvent == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userInEvent.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", userInEvent.EventId);
            return View(userInEvent);
        }

        // POST: Admin/UserInEvent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EventId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] UserInEvent userInEvent)
        {
            if (id != userInEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInEventExists(userInEvent.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userInEvent.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", userInEvent.EventId);
            return View(userInEvent);
        }

        // GET: Admin/UserInEvent/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.UserInEvents == null)
            {
                return NotFound();
            }

            var userInEvent = await _context.UserInEvents
                .Include(u => u.AppUser)
                .Include(u => u.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInEvent == null)
            {
                return NotFound();
            }

            return View(userInEvent);
        }

        // POST: Admin/UserInEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.UserInEvents == null)
            {
                return Problem("Entity set 'AppDbContext.UserInEvents'  is null.");
            }
            var userInEvent = await _context.UserInEvents.FindAsync(id);
            if (userInEvent != null)
            {
                _context.UserInEvents.Remove(userInEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInEventExists(Guid id)
        {
          return (_context.UserInEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
