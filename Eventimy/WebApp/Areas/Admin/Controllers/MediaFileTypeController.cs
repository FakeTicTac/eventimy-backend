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
    public class MediaFileTypeController : Controller
    {
        private readonly AppDbContext _context;

        public MediaFileTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MediaFileType
        public async Task<IActionResult> Index()
        {
              return _context.MediaFileTypes != null ? 
                          View(await _context.MediaFileTypes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.MediaFileTypes'  is null.");
        }

        // GET: Admin/MediaFileType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.MediaFileTypes == null)
            {
                return NotFound();
            }

            var mediaFileType = await _context.MediaFileTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaFileType == null)
            {
                return NotFound();
            }

            return View(mediaFileType);
        }

        // GET: Admin/MediaFileType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MediaFileType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SignImagePath,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] MediaFileType mediaFileType)
        {
            if (ModelState.IsValid)
            {
                mediaFileType.Id = Guid.NewGuid();
                _context.Add(mediaFileType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaFileType);
        }

        // GET: Admin/MediaFileType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.MediaFileTypes == null)
            {
                return NotFound();
            }

            var mediaFileType = await _context.MediaFileTypes.FindAsync(id);
            if (mediaFileType == null)
            {
                return NotFound();
            }
            return View(mediaFileType);
        }

        // POST: Admin/MediaFileType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,SignImagePath,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] MediaFileType mediaFileType)
        {
            if (id != mediaFileType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaFileType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaFileTypeExists(mediaFileType.Id))
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
            return View(mediaFileType);
        }

        // GET: Admin/MediaFileType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.MediaFileTypes == null)
            {
                return NotFound();
            }

            var mediaFileType = await _context.MediaFileTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaFileType == null)
            {
                return NotFound();
            }

            return View(mediaFileType);
        }

        // POST: Admin/MediaFileType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.MediaFileTypes == null)
            {
                return Problem("Entity set 'AppDbContext.MediaFileTypes'  is null.");
            }
            var mediaFileType = await _context.MediaFileTypes.FindAsync(id);
            if (mediaFileType != null)
            {
                _context.MediaFileTypes.Remove(mediaFileType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaFileTypeExists(Guid id)
        {
          return (_context.MediaFileTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
