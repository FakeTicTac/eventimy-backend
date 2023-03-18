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
    public class EventCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public EventCategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/EventCategory
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EventCategories.Include(e => e.ParentCategory);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/EventCategory/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EventCategories == null)
            {
                return NotFound();
            }

            var eventCategory = await _context.EventCategories
                .Include(e => e.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventCategory == null)
            {
                return NotFound();
            }

            return View(eventCategory);
        }

        // GET: Admin/EventCategory/Create
        public IActionResult Create()
        {
            ViewData["ParentCategoryId"] = new SelectList(_context.EventCategories, "Id", "Id");
            return View();
        }

        // POST: Admin/EventCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,SignImagePath,ParentCategoryId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] EventCategory eventCategory)
        {
            if (ModelState.IsValid)
            {
                eventCategory.Id = Guid.NewGuid();
                _context.Add(eventCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentCategoryId"] = new SelectList(_context.EventCategories, "Id", "Id", eventCategory.ParentCategoryId);
            return View(eventCategory);
        }

        // GET: Admin/EventCategory/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EventCategories == null)
            {
                return NotFound();
            }

            var eventCategory = await _context.EventCategories.FindAsync(id);
            if (eventCategory == null)
            {
                return NotFound();
            }
            ViewData["ParentCategoryId"] = new SelectList(_context.EventCategories, "Id", "Id", eventCategory.ParentCategoryId);
            return View(eventCategory);
        }

        // POST: Admin/EventCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Description,SignImagePath,ParentCategoryId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] EventCategory eventCategory)
        {
            if (id != eventCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventCategoryExists(eventCategory.Id))
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
            ViewData["ParentCategoryId"] = new SelectList(_context.EventCategories, "Id", "Id", eventCategory.ParentCategoryId);
            return View(eventCategory);
        }

        // GET: Admin/EventCategory/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EventCategories == null)
            {
                return NotFound();
            }

            var eventCategory = await _context.EventCategories
                .Include(e => e.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventCategory == null)
            {
                return NotFound();
            }

            return View(eventCategory);
        }

        // POST: Admin/EventCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EventCategories == null)
            {
                return Problem("Entity set 'AppDbContext.EventCategories'  is null.");
            }
            var eventCategory = await _context.EventCategories.FindAsync(id);
            if (eventCategory != null)
            {
                _context.EventCategories.Remove(eventCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventCategoryExists(Guid id)
        {
          return (_context.EventCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
