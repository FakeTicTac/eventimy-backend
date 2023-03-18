using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaFileTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MediaFileTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MediaFileType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaFileType>>> GetMediaFileTypes()
        {
          if (_context.MediaFileTypes == null)
          {
              return NotFound();
          }
            return await _context.MediaFileTypes.ToListAsync();
        }

        // GET: api/MediaFileType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaFileType>> GetMediaFileType(Guid id)
        {
          if (_context.MediaFileTypes == null)
          {
              return NotFound();
          }
            var mediaFileType = await _context.MediaFileTypes.FindAsync(id);

            if (mediaFileType == null)
            {
                return NotFound();
            }

            return mediaFileType;
        }

        // PUT: api/MediaFileType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaFileType(Guid id, MediaFileType mediaFileType)
        {
            if (id != mediaFileType.Id)
            {
                return BadRequest();
            }

            _context.Entry(mediaFileType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaFileTypeExists(id))
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

        // POST: api/MediaFileType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediaFileType>> PostMediaFileType(MediaFileType mediaFileType)
        {
          if (_context.MediaFileTypes == null)
          {
              return Problem("Entity set 'AppDbContext.MediaFileTypes'  is null.");
          }
            _context.MediaFileTypes.Add(mediaFileType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediaFileType", new { id = mediaFileType.Id }, mediaFileType);
        }

        // DELETE: api/MediaFileType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaFileType(Guid id)
        {
            if (_context.MediaFileTypes == null)
            {
                return NotFound();
            }
            var mediaFileType = await _context.MediaFileTypes.FindAsync(id);
            if (mediaFileType == null)
            {
                return NotFound();
            }

            _context.MediaFileTypes.Remove(mediaFileType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediaFileTypeExists(Guid id)
        {
            return (_context.MediaFileTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
