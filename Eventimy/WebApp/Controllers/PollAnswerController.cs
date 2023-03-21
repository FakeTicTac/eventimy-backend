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
    public class PollAnswerController : Controller
    {
        private readonly AppDbContext _context;

        public PollAnswerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PollAnswer
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PollAnswers.Include(p => p.ChatParticipant).Include(p => p.PollOption);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PollAnswer/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PollAnswers == null)
            {
                return NotFound();
            }

            var pollAnswer = await _context.PollAnswers
                .Include(p => p.ChatParticipant)
                .Include(p => p.PollOption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pollAnswer == null)
            {
                return NotFound();
            }

            return View(pollAnswer);
        }

        // GET: PollAnswer/Create
        public IActionResult Create()
        {
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id");
            ViewData["PollOptionId"] = new SelectList(_context.PollOptions, "Id", "Id");
            return View();
        }

        // POST: PollAnswer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChatParticipantId,PollOptionId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] PollAnswer pollAnswer)
        {
            if (ModelState.IsValid)
            {
                pollAnswer.Id = Guid.NewGuid();
                _context.Add(pollAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", pollAnswer.ChatParticipantId);
            ViewData["PollOptionId"] = new SelectList(_context.PollOptions, "Id", "Id", pollAnswer.PollOptionId);
            return View(pollAnswer);
        }

        // GET: PollAnswer/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PollAnswers == null)
            {
                return NotFound();
            }

            var pollAnswer = await _context.PollAnswers.FindAsync(id);
            if (pollAnswer == null)
            {
                return NotFound();
            }
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", pollAnswer.ChatParticipantId);
            ViewData["PollOptionId"] = new SelectList(_context.PollOptions, "Id", "Id", pollAnswer.PollOptionId);
            return View(pollAnswer);
        }

        // POST: PollAnswer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ChatParticipantId,PollOptionId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] PollAnswer pollAnswer)
        {
            if (id != pollAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pollAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PollAnswerExists(pollAnswer.Id))
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
            ViewData["ChatParticipantId"] = new SelectList(_context.ChatParticipants, "Id", "Id", pollAnswer.ChatParticipantId);
            ViewData["PollOptionId"] = new SelectList(_context.PollOptions, "Id", "Id", pollAnswer.PollOptionId);
            return View(pollAnswer);
        }

        // GET: PollAnswer/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PollAnswers == null)
            {
                return NotFound();
            }

            var pollAnswer = await _context.PollAnswers
                .Include(p => p.ChatParticipant)
                .Include(p => p.PollOption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pollAnswer == null)
            {
                return NotFound();
            }

            return View(pollAnswer);
        }

        // POST: PollAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PollAnswers == null)
            {
                return Problem("Entity set 'AppDbContext.PollAnswers'  is null.");
            }
            var pollAnswer = await _context.PollAnswers.FindAsync(id);
            if (pollAnswer != null)
            {
                _context.PollAnswers.Remove(pollAnswer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PollAnswerExists(Guid id)
        {
          return (_context.PollAnswers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
