using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain.Identity;

namespace WebApp.Controllers.Identity
{
    public class RefreshTokenController : Controller
    {
        private readonly AppDbContext _context;

        public RefreshTokenController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RefreshToken
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RefreshTokens.Include(r => r.AppUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: RefreshToken/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RefreshTokens == null)
            {
                return NotFound();
            }

            var refreshToken = await _context.RefreshTokens
                .Include(r => r.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refreshToken == null)
            {
                return NotFound();
            }

            return View(refreshToken);
        }

        // GET: RefreshToken/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: RefreshToken/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Signature,ExpirationDateTime,PreviousSignature,PreviousExpirationDateTime,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] RefreshToken refreshToken)
        {
            if (ModelState.IsValid)
            {
                refreshToken.Id = Guid.NewGuid();
                _context.Add(refreshToken);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", refreshToken.AppUserId);
            return View(refreshToken);
        }

        // GET: RefreshToken/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RefreshTokens == null)
            {
                return NotFound();
            }

            var refreshToken = await _context.RefreshTokens.FindAsync(id);
            if (refreshToken == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", refreshToken.AppUserId);
            return View(refreshToken);
        }

        // POST: RefreshToken/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Signature,ExpirationDateTime,PreviousSignature,PreviousExpirationDateTime,AppUserId,CreatedBy,CreatedAt,ModifiedBy,ModifiedAt,Id")] RefreshToken refreshToken)
        {
            if (id != refreshToken.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refreshToken);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefreshTokenExists(refreshToken.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", refreshToken.AppUserId);
            return View(refreshToken);
        }

        // GET: RefreshToken/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RefreshTokens == null)
            {
                return NotFound();
            }

            var refreshToken = await _context.RefreshTokens
                .Include(r => r.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refreshToken == null)
            {
                return NotFound();
            }

            return View(refreshToken);
        }

        // POST: RefreshToken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RefreshTokens == null)
            {
                return Problem("Entity set 'AppDbContext.RefreshTokens'  is null.");
            }
            var refreshToken = await _context.RefreshTokens.FindAsync(id);
            if (refreshToken != null)
            {
                _context.RefreshTokens.Remove(refreshToken);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefreshTokenExists(Guid id)
        {
          return (_context.RefreshTokens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
