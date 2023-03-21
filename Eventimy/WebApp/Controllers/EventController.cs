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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Events
                .Include(e => e.AppUser)
                .Include(e => e.City)
                .Include(e => e.EventCategory)
                .Include(e => e.ParentEvent);
            
            return View(await appDbContext.ToListAsync());
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.AppUser)
                .Include(e => e.City)
                .Include(e => e.EventCategory)
                .Include(e => e.ParentEvent)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            ViewData["EventCategoryId"] = new SelectList(_context.EventCategories, "Id", "Id");
            ViewData["ParentEventId"] = new SelectList(_context.Events, "Id", "Id");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Summary,Description,EventWebsite,MaxParticipantAmount,MinParticipantAmount,TicketBuyingWebsite,IsPrivate,IsFree,Address,StartTime,EndTime,Latitude,Longitude,CoverImagePath,ThumbNailImage,CityId,ParentEventId,EventCategoryId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.Id = Guid.NewGuid();
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", @event.AppUserId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", @event.CityId);
            ViewData["EventCategoryId"] = new SelectList(_context.EventCategories, "Id", "Id", @event.EventCategoryId);
            ViewData["ParentEventId"] = new SelectList(_context.Events, "Id", "Id", @event.ParentEventId);
            return View(@event);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", @event.AppUserId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", @event.CityId);
            ViewData["EventCategoryId"] = new SelectList(_context.EventCategories, "Id", "Id", @event.EventCategoryId);
            ViewData["ParentEventId"] = new SelectList(_context.Events, "Id", "Id", @event.ParentEventId);
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Summary,Description,EventWebsite,MaxParticipantAmount,MinParticipantAmount,TicketBuyingWebsite,IsPrivate,IsFree,Address,StartTime,EndTime,Latitude,Longitude,CoverImagePath,ThumbNailImage,CityId,ParentEventId,EventCategoryId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", @event.AppUserId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", @event.CityId);
            ViewData["EventCategoryId"] = new SelectList(_context.EventCategories, "Id", "Id", @event.EventCategoryId);
            ViewData["ParentEventId"] = new SelectList(_context.Events, "Id", "Id", @event.ParentEventId);
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.AppUser)
                .Include(e => e.City)
                .Include(e => e.EventCategory)
                .Include(e => e.ParentEvent)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'AppDbContext.Events'  is null.");
            }
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(Guid id)
        {
          return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
