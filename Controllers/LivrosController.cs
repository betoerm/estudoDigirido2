using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrosApi.Models;

namespace LivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosContext _context;

        public LivrosController(LivrosContext context)
        {
            _context = context;

            if (_context.LivrosItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.LivrosItems.Add(new LivrosItem { Nome = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivrosItem>>> GetLivrosItems()
        {
            return await _context.LivrosItems.ToListAsync();
        }

        // GET: api/Livros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LivrosItem>> GetLivrosItem(long id)
        {
            var LivrosItem = await _context.LivrosItems.FindAsync(id);

            if (LivrosItem == null)
            {
                return NotFound();
            }

            return LivrosItem;
        }

        // POST: api/Livros
        [HttpPost]
        public async Task<ActionResult<LivrosItem>> PostLivrosItem(LivrosItem item)
        {
            _context.LivrosItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLivrosItem), new { id = item.Id }, item);
        }

        // PUT: api/Livros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivrosItem(long id, LivrosItem item)
        {

            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivroItem(long id)
        {
            var LivrosItem = await _context.LivrosItems.FindAsync(id);

            if (LivrosItem == null)
            {
                return NotFound();
            }

            _context.LivrosItems.Remove(LivrosItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}