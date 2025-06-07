using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hesol.Connection;
using Hesol.Models;

namespace Hesol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocalsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Locals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Local>>> GetLocal()
        {
            return await _context.Local.ToListAsync();
        }

        // GET: api/Locals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Local>> GetLocal(int id)
        {
            var local = await _context.Local.FindAsync(id);

            if (local == null)
            {
                return NotFound();
            }

            return local;
        }

        // PUT: api/Locals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocal(int id, Local local)
        {
            if (id != local.IdLocal)
            {
                return BadRequest();
            }

            _context.Entry(local).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalExists(id))
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

        // POST: api/Locals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Local>> PostLocal(Local local)
        {
            _context.Local.Add(local);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocal", new { id = local.IdLocal }, local);
        }

        // DELETE: api/Locals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(int id)
        {
            var local = await _context.Local.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }

            _context.Local.Remove(local);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalExists(int id)
        {
            return _context.Local.Any(e => e.IdLocal == id);
        }
    }
}
