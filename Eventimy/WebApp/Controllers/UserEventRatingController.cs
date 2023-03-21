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
    public class UserEventRatingController : Controller
    {
        private readonly AppDbContext _context;

        public UserEventRatingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserEventRating
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserEventRatings.Include(u => u.AppUser).Include(u => u.Event);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserEventRating/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.UserEventRatings == null)
            {
                return NotFound();
            }

            var userEventRating = await _context.UserEventRatings
                .Include(u => u.AppUser)
                .Include(u => u.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEventRating == null)
            {
                return NotFound();
            }

            return View(userEventRating);
        }

        // GET: UserEventRating/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            return View();
        }

        // POST: UserEventRating/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RatingValue,EventId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] UserEventRating userEventRating)
        {
            if (ModelState.IsValid)
            {
                userEventRating.Id = Guid.NewGuid();
                _context.Add(userEventRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userEventRating.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", userEventRating.EventId);
            return View(userEventRating);
        }

        // GET: UserEventRating/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.UserEventRatings == null)
            {
                return NotFound();
            }

            var userEventRating = await _context.UserEventRatings.FindAsync(id);
            if (userEventRating == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userEventRating.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", userEventRating.EventId);
            return View(userEventRating);
        }

        // POST: UserEventRating/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RatingValue,EventId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] UserEventRating userEventRating)
        {
            if (id != userEventRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEventRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEventRatingExists(userEventRating.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", userEventRating.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", userEventRating.EventId);
            return View(userEventRating);
        }

        // GET: UserEventRating/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.UserEventRatings == null)
            {
                return NotFound();
            }

            var userEventRating = await _context.UserEventRatings
                .Include(u => u.AppUser)
                .Include(u => u.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEventRating == null)
            {
                return NotFound();
            }

            return View(userEventRating);
        }

        // POST: UserEventRating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.UserEventRatings == null)
            {
                return Problem("Entity set 'AppDbContext.UserEventRatings'  is null.");
            }
            var userEventRating = await _context.UserEventRatings.FindAsync(id);
            if (userEventRating != null)
            {
                _context.UserEventRatings.Remove(userEventRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEventRatingExists(Guid id)
        {
          return (_context.UserEventRatings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
