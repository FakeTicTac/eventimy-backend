using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain.Identity;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshTokenController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RefreshTokenController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RefreshToken
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefreshToken>>> GetRefreshTokens()
        {
          if (_context.RefreshTokens == null)
          {
              return NotFound();
          }
            return await _context.RefreshTokens.ToListAsync();
        }

        // GET: api/RefreshToken/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RefreshToken>> GetRefreshToken(Guid id)
        {
          if (_context.RefreshTokens == null)
          {
              return NotFound();
          }
            var refreshToken = await _context.RefreshTokens.FindAsync(id);

            if (refreshToken == null)
            {
                return NotFound();
            }

            return refreshToken;
        }

        // PUT: api/RefreshToken/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefreshToken(Guid id, RefreshToken refreshToken)
        {
            if (id != refreshToken.Id)
            {
                return BadRequest();
            }

            _context.Entry(refreshToken).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefreshTokenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RefreshToken
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RefreshToken>> PostRefreshToken(RefreshToken refreshToken)
        {
          if (_context.RefreshTokens == null)
          {
              return Problem("Entity set 'AppDbContext.RefreshTokens'  is null.");
          }
            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRefreshToken", new { id = refreshToken.Id }, refreshToken);
        }

        // DELETE: api/RefreshToken/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefreshToken(Guid id)
        {
            if (_context.RefreshTokens == null)
            {
                return NotFound();
            }
            var refreshToken = await _context.RefreshTokens.FindAsync(id);
            if (refreshToken == null)
            {
                return NotFound();
            }

            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RefreshTokenExists(Guid id)
        {
            return (_context.RefreshTokens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
