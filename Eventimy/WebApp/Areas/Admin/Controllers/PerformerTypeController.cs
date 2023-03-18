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
    public class PerformerTypeController : Controller
    {
        private readonly AppDbContext _context;

        public PerformerTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PerformerType
        public async Task<IActionResult> Index()
        {
              return _context.PerformerTypes != null ? 
                          View(await _context.PerformerTypes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.PerformerTypes'  is null.");
        }

        // GET: Admin/PerformerType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PerformerTypes == null)
            {
                return NotFound();
            }

            var performerType = await _context.PerformerTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performerType == null)
            {
                return NotFound();
            }

            return View(performerType);
        }

        // GET: Admin/PerformerType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PerformerType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SignImagePath,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] PerformerType performerType)
        {
            if (ModelState.IsValid)
            {
                performerType.Id = Guid.NewGuid();
                _context.Add(performerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(performerType);
        }

        // GET: Admin/PerformerType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PerformerTypes == null)
            {
                return NotFound();
            }

            var performerType = await _context.PerformerTypes.FindAsync(id);
            if (performerType == null)
            {
                return NotFound();
            }
            return View(performerType);
        }

        // POST: Admin/PerformerType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,SignImagePath,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] PerformerType performerType)
        {
            if (id != performerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformerTypeExists(performerType.Id))
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
            return View(performerType);
        }

        // GET: Admin/PerformerType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PerformerTypes == null)
            {
                return NotFound();
            }

            var performerType = await _context.PerformerTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performerType == null)
            {
                return NotFound();
            }

            return View(performerType);
        }

        // POST: Admin/PerformerType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PerformerTypes == null)
            {
                return Problem("Entity set 'AppDbContext.PerformerTypes'  is null.");
            }
            var performerType = await _context.PerformerTypes.FindAsync(id);
            if (performerType != null)
            {
                _context.PerformerTypes.Remove(performerType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformerTypeExists(Guid id)
        {
          return (_context.PerformerTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
