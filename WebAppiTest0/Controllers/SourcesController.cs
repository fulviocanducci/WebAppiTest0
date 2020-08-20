using Canducci.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppiTest0.Models;

namespace WebAppiTest0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        private readonly DatabaseSource _context;

        public SourcesController(DatabaseSource context)
        {
            _context = context;
        }

        // GET: api/Sources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Source>>> GetSource(int? limit)
        {
            return await _context
                    .Source
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .Take(limit ?? 100)
                    .ToListAsync();
        }

        [HttpGet("page/{page?}")]
        public async Task<IActionResult> GetSourcePaginated(int? page)
        {
            page ??= 1;
            if (page <= 0) page = 1;

            var result = await _context
                    .Source
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .ToPaginatedRestAsync(page.Value, 10);
            return Ok(result);
        }

        // GET: api/Sources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Source>> GetSource(int id)
        {
            var source = await _context.Source.FindAsync(id);

            if (source == null)
            {
                return NotFound();
            }

            return source;
        }

        // PUT: api/Sources/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSource(int id, Source source)
        {
            if (id != source.Id)
            {
                return BadRequest();
            }

            _context.Entry(source).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourceExists(id))
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

        // POST: api/Sources
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Source>> PostSource(Source source)
        {
            _context.Source.Add(source);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSource", new { id = source.Id }, source);
        }

        // DELETE: api/Sources/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Source>> DeleteSource(int id)
        {
            var source = await _context.Source.FindAsync(id);
            if (source == null)
            {
                return NotFound();
            }

            _context.Source.Remove(source);
            await _context.SaveChangesAsync();

            return source;
        }

        private bool SourceExists(int id)
        {
            return _context.Source.Any(e => e.Id == id);
        }
    }
}
