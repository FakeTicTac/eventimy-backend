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
    public class PerformerController : Controller
    {
        private readonly AppDbContext _context;

        public PerformerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Performer
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Performers.Include(p => p.AppUser).Include(p => p.Event).Include(p => p.PerformerType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Performer/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Performers == null)
            {
                return NotFound();
            }

            var performer = await _context.Performers
                .Include(p => p.AppUser)
                .Include(p => p.Event)
                .Include(p => p.PerformerType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performer == null)
            {
                return NotFound();
            }

            return View(performer);
        }

        // GET: Performer/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["PerformerTypeId"] = new SelectList(_context.PerformerTypes, "Id", "Id");
            return View();
        }

        // POST: Performer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,CoverImage,EventId,PerformerTypeId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] Performer performer)
        {
            if (ModelState.IsValid)
            {
                performer.Id = Guid.NewGuid();
                _context.Add(performer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", performer.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", performer.EventId);
            ViewData["PerformerTypeId"] = new SelectList(_context.PerformerTypes, "Id", "Id", performer.PerformerTypeId);
            return View(performer);
        }

        // GET: Performer/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Performers == null)
            {
                return NotFound();
            }

            var performer = await _context.Performers.FindAsync(id);
            if (performer == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", performer.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", performer.EventId);
            ViewData["PerformerTypeId"] = new SelectList(_context.PerformerTypes, "Id", "Id", performer.PerformerTypeId);
            return View(performer);
        }

        // POST: Performer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,CoverImage,EventId,PerformerTypeId,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] Performer performer)
        {
            if (id != performer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformerExists(performer.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", performer.AppUserId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", performer.EventId);
            ViewData["PerformerTypeId"] = new SelectList(_context.PerformerTypes, "Id", "Id", performer.PerformerTypeId);
            return View(performer);
        }

        // GET: Performer/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Performers == null)
            {
                return NotFound();
            }

            var performer = await _context.Performers
                .Include(p => p.AppUser)
                .Include(p => p.Event)
                .Include(p => p.PerformerType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performer == null)
            {
                return NotFound();
            }

            return View(performer);
        }

        // POST: Performer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Performers == null)
            {
                return Problem("Entity set 'AppDbContext.Performers'  is null.");
            }
            var performer = await _context.Performers.FindAsync(id);
            if (performer != null)
            {
                _context.Performers.Remove(performer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformerExists(Guid id)
        {
          return (_context.Performers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
