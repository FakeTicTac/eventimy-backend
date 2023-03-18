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
    public class ReactionTypeController : Controller
    {
        private readonly AppDbContext _context;

        public ReactionTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ReactionType
        public async Task<IActionResult> Index()
        {
              return _context.ReactionTypes != null ? 
                          View(await _context.ReactionTypes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.ReactionTypes'  is null.");
        }

        // GET: Admin/ReactionType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ReactionTypes == null)
            {
                return NotFound();
            }

            var reactionType = await _context.ReactionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reactionType == null)
            {
                return NotFound();
            }

            return View(reactionType);
        }

        // GET: Admin/ReactionType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ReactionType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SignImagePath,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ReactionType reactionType)
        {
            if (ModelState.IsValid)
            {
                reactionType.Id = Guid.NewGuid();
                _context.Add(reactionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reactionType);
        }

        // GET: Admin/ReactionType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ReactionTypes == null)
            {
                return NotFound();
            }

            var reactionType = await _context.ReactionTypes.FindAsync(id);
            if (reactionType == null)
            {
                return NotFound();
            }
            return View(reactionType);
        }

        // POST: Admin/ReactionType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,SignImagePath,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] ReactionType reactionType)
        {
            if (id != reactionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reactionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReactionTypeExists(reactionType.Id))
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
            return View(reactionType);
        }

        // GET: Admin/ReactionType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ReactionTypes == null)
            {
                return NotFound();
            }

            var reactionType = await _context.ReactionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reactionType == null)
            {
                return NotFound();
            }

            return View(reactionType);
        }

        // POST: Admin/ReactionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ReactionTypes == null)
            {
                return Problem("Entity set 'AppDbContext.ReactionTypes'  is null.");
            }
            var reactionType = await _context.ReactionTypes.FindAsync(id);
            if (reactionType != null)
            {
                _context.ReactionTypes.Remove(reactionType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReactionTypeExists(Guid id)
        {
          return (_context.ReactionTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
