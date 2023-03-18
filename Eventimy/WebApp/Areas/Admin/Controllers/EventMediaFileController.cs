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
    public class EventMediaFileController : Controller
    {
        private readonly AppDbContext _context;

        public EventMediaFileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/EventMediaFile
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EventMediaFiles.Include(e => e.Event).Include(e => e.MediaFileType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/EventMediaFile/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EventMediaFiles == null)
            {
                return NotFound();
            }

            var eventMediaFile = await _context.EventMediaFiles
                .Include(e => e.Event)
                .Include(e => e.MediaFileType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventMediaFile == null)
            {
                return NotFound();
            }

            return View(eventMediaFile);
        }

        // GET: Admin/EventMediaFile/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["MediaFileTypeId"] = new SelectList(_context.MediaFileTypes, "Id", "Id");
            return View();
        }

        // POST: Admin/EventMediaFile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediaFile,EventId,MediaFileTypeId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] EventMediaFile eventMediaFile)
        {
            if (ModelState.IsValid)
            {
                eventMediaFile.Id = Guid.NewGuid();
                _context.Add(eventMediaFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventMediaFile.EventId);
            ViewData["MediaFileTypeId"] = new SelectList(_context.MediaFileTypes, "Id", "Id", eventMediaFile.MediaFileTypeId);
            return View(eventMediaFile);
        }

        // GET: Admin/EventMediaFile/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EventMediaFiles == null)
            {
                return NotFound();
            }

            var eventMediaFile = await _context.EventMediaFiles.FindAsync(id);
            if (eventMediaFile == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventMediaFile.EventId);
            ViewData["MediaFileTypeId"] = new SelectList(_context.MediaFileTypes, "Id", "Id", eventMediaFile.MediaFileTypeId);
            return View(eventMediaFile);
        }

        // POST: Admin/EventMediaFile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MediaFile,EventId,MediaFileTypeId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] EventMediaFile eventMediaFile)
        {
            if (id != eventMediaFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventMediaFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventMediaFileExists(eventMediaFile.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventMediaFile.EventId);
            ViewData["MediaFileTypeId"] = new SelectList(_context.MediaFileTypes, "Id", "Id", eventMediaFile.MediaFileTypeId);
            return View(eventMediaFile);
        }

        // GET: Admin/EventMediaFile/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EventMediaFiles == null)
            {
                return NotFound();
            }

            var eventMediaFile = await _context.EventMediaFiles
                .Include(e => e.Event)
                .Include(e => e.MediaFileType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventMediaFile == null)
            {
                return NotFound();
            }

            return View(eventMediaFile);
        }

        // POST: Admin/EventMediaFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EventMediaFiles == null)
            {
                return Problem("Entity set 'AppDbContext.EventMediaFiles'  is null.");
            }
            var eventMediaFile = await _context.EventMediaFiles.FindAsync(id);
            if (eventMediaFile != null)
            {
                _context.EventMediaFiles.Remove(eventMediaFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventMediaFileExists(Guid id)
        {
          return (_context.EventMediaFiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
