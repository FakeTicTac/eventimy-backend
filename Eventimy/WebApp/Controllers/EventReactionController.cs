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
    public class EventReactionController : Controller
    {
        private readonly AppDbContext _context;

        public EventReactionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventReaction
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EventReactions.Include(e => e.AppUser).Include(e => e.Event).Include(e => e.ReactionType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EventReaction/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EventReactions == null)
            {
                return NotFound();
            }

            var eventReaction = await _context.EventReactions
                .Include(e => e.AppUser)
                .Include(e => e.Event)
                .Include(e => e.ReactionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventReaction == null)
            {
                return NotFound();
            }

            return View(eventReaction);
        }

        // GET: EventReaction/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["ReactionTypeId"] = new SelectList(_context.ReactionTypes, "Id", "Id");
            return View();
        }

        // POST: EventReaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,ReactionTypeId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] EventReaction eventReaction)
        {
            if (ModelState.IsValid)
            {
                eventReaction.Id = Guid.NewGuid();
                _context.Add(eventReaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", eventReaction.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventReaction.EventId);
            ViewData["ReactionTypeId"] = new SelectList(_context.ReactionTypes, "Id", "Id", eventReaction.ReactionTypeId);
            return View(eventReaction);
        }

        // GET: EventReaction/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EventReactions == null)
            {
                return NotFound();
            }

            var eventReaction = await _context.EventReactions.FindAsync(id);
            if (eventReaction == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", eventReaction.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventReaction.EventId);
            ViewData["ReactionTypeId"] = new SelectList(_context.ReactionTypes, "Id", "Id", eventReaction.ReactionTypeId);
            return View(eventReaction);
        }

        // POST: EventReaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EventId,ReactionTypeId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] EventReaction eventReaction)
        {
            if (id != eventReaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventReaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventReactionExists(eventReaction.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", eventReaction.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventReaction.EventId);
            ViewData["ReactionTypeId"] = new SelectList(_context.ReactionTypes, "Id", "Id", eventReaction.ReactionTypeId);
            return View(eventReaction);
        }

        // GET: EventReaction/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EventReactions == null)
            {
                return NotFound();
            }

            var eventReaction = await _context.EventReactions
                .Include(e => e.AppUser)
                .Include(e => e.Event)
                .Include(e => e.ReactionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventReaction == null)
            {
                return NotFound();
            }

            return View(eventReaction);
        }

        // POST: EventReaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EventReactions == null)
            {
                return Problem("Entity set 'AppDbContext.EventReactions'  is null.");
            }
            var eventReaction = await _context.EventReactions.FindAsync(id);
            if (eventReaction != null)
            {
                _context.EventReactions.Remove(eventReaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventReactionExists(Guid id)
        {
          return (_context.EventReactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
