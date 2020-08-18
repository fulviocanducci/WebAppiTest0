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
    public class CreditsController : ControllerBase
    {
        private readonly DatabaseSource _context;

        public CreditsController(DatabaseSource context)
        {
            _context = context;
            //Credit[] credits = new Credit[5000];
            //Source[] sources = new Source[5000];
            //for (int i = 0; i < 5000; i++)
            //{
            //    credits[i] = new Credit { Title = Faker.Name.FullName() };
            //    sources[i] = new Source { Description = Faker.Name.FullName() };
            //}
            //_context.AddRange(credits);
            //_context.AddRange(sources);
            //_context.SaveChanges();
        }

        // GET: api/Credits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Credit>>> GetCredit()
        {
            return await _context.Credit.ToListAsync();
        }

        // GET: api/Credits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Credit>> GetCredit(int id)
        {
            var credit = await _context.Credit.FindAsync(id);

            if (credit == null)
            {
                return NotFound();
            }

            return credit;
        }

        // PUT: api/Credits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCredit(int id, Credit credit)
        {
            if (id != credit.Id)
            {
                return BadRequest();
            }

            _context.Entry(credit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditExists(id))
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

        // POST: api/Credits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Credit>> PostCredit(Credit credit)
        {
            _context.Credit.Add(credit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCredit", new { id = credit.Id }, credit);
        }

        // DELETE: api/Credits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Credit>> DeleteCredit(int id)
        {
            var credit = await _context.Credit.FindAsync(id);
            if (credit == null)
            {
                return NotFound();
            }

            _context.Credit.Remove(credit);
            await _context.SaveChangesAsync();

            return credit;
        }

        private bool CreditExists(int id)
        {
            return _context.Credit.Any(e => e.Id == id);
        }
    }
}
