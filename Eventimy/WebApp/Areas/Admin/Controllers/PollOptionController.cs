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
    public class PollOptionController : Controller
    {
        private readonly AppDbContext _context;

        public PollOptionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PollOption
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PollOptions.Include(p => p.ChatPoll);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/PollOption/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PollOptions == null)
            {
                return NotFound();
            }

            var pollOption = await _context.PollOptions
                .Include(p => p.ChatPoll)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pollOption == null)
            {
                return NotFound();
            }

            return View(pollOption);
        }

        // GET: Admin/PollOption/Create
        public IActionResult Create()
        {
            ViewData["ChatPollId"] = new SelectList(_context.ChatPolls, "Id", "Id");
            return View();
        }

        // POST: Admin/PollOption/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,ChatPollId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] PollOption pollOption)
        {
            if (ModelState.IsValid)
            {
                pollOption.Id = Guid.NewGuid();
                _context.Add(pollOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChatPollId"] = new SelectList(_context.ChatPolls, "Id", "Id", pollOption.ChatPollId);
            return View(pollOption);
        }

        // GET: Admin/PollOption/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PollOptions == null)
            {
                return NotFound();
            }

            var pollOption = await _context.PollOptions.FindAsync(id);
            if (pollOption == null)
            {
                return NotFound();
            }
            ViewData["ChatPollId"] = new SelectList(_context.ChatPolls, "Id", "Id", pollOption.ChatPollId);
            return View(pollOption);
        }

        // POST: Admin/PollOption/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Value,ChatPollId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] PollOption pollOption)
        {
            if (id != pollOption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pollOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PollOptionExists(pollOption.Id))
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
            ViewData["ChatPollId"] = new SelectList(_context.ChatPolls, "Id", "Id", pollOption.ChatPollId);
            return View(pollOption);
        }

        // GET: Admin/PollOption/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PollOptions == null)
            {
                return NotFound();
            }

            var pollOption = await _context.PollOptions
                .Include(p => p.ChatPoll)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pollOption == null)
            {
                return NotFound();
            }

            return View(pollOption);
        }

        // POST: Admin/PollOption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PollOptions == null)
            {
                return Problem("Entity set 'AppDbContext.PollOptions'  is null.");
            }
            var pollOption = await _context.PollOptions.FindAsync(id);
            if (pollOption != null)
            {
                _context.PollOptions.Remove(pollOption);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PollOptionExists(Guid id)
        {
          return (_context.PollOptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
