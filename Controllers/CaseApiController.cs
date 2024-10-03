using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseManagementPortal.Data;
using CaseManagementPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseManagementPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CaseApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Case>>> GetCases()
        {
            return await _context.Cases.Include(c => c.Client).ToListAsync();
        }

        // GET: api/CaseApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetCase(int id)
        {
            var caseItem = await _context.Cases.Include(c => c.Client).FirstOrDefaultAsync(c => c.CaseId == id);

            if (caseItem == null)
            {
                return NotFound();
            }

            return caseItem;
        }

        // POST: api/CaseApi
        [HttpPost]
        public async Task<ActionResult<Case>> PostCase(Case caseItem)
        {
            _context.Cases.Add(caseItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCase", new { id = caseItem.CaseId }, caseItem);
        }

        // PUT: api/CaseApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCase(int id, Case caseItem)
        {
            if (id != caseItem.CaseId)
            {
                return BadRequest();
            }

            _context.Entry(caseItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/CaseApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var caseItem = await _context.Cases.FindAsync(id);
            if (caseItem == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(caseItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
