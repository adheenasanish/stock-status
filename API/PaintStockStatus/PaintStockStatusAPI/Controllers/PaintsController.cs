using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintStockStatusAPI.Data;
using PaintStockStatusAPI.Models;

namespace PaintStockStatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintsController : ControllerBase
    {
        private readonly PaintStockDbContext _context;

        public PaintsController(PaintStockDbContext context)
        {
            _context = context;
        }

        // GET: api/Paints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paint>>> GetAllPaints()
        {
            return await _context.Paints.ToListAsync();
        }

        //public IActionResult GetForPainters()
        //{
        //   // var paintsForPainters = _context.Paints.Where(p => p.
        //}

        // GET: api/Paints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paint>> GetPaint(int id)
        {
            var paint = await _context.Paints.FindAsync(id);

            if (paint == null)
            {
                return NotFound();
            }

            return paint;
        }

        // PUT: api/Paints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaint(int id, Paint paint)
        {
            if (id != paint.Id)
            {
                return BadRequest();
            }

            _context.Entry(paint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintExists(id))
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

        // POST: api/Paints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paint>> AddPaint(Paint paint)
        {
            _context.Paints.Add(paint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaint", new { id = paint.Id }, paint);
        }

        // DELETE: api/Paints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaint(int id)
        {
            var paint = await _context.Paints.FindAsync(id);
            if (paint == null)
            {
                return NotFound();
            }

            _context.Paints.Remove(paint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaintExists(int id)
        {
            return _context.Paints.Any(e => e.Id == id);
        }
    }
}
