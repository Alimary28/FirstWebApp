using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstWebApp.Models;

namespace FirstWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterItemsController : ControllerBase
    {
        private readonly CharacterContext _context;

        public CharacterItemsController(CharacterContext context)
        {
            _context = context;
        }

        // GET: api/CharacterItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterItem>>> GetCharacterItems()
        {
            return await _context.CharacterItems.ToListAsync();
        }

        // GET: api/CharacterItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterItem>> GetCharacterItem(long id)
        {
            var characterItem = await _context.CharacterItems.FindAsync(id);

            if (characterItem == null)
            {
                return NotFound();
            }

            return characterItem;
        }

        // PUT: api/CharacterItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterItem(long id, CharacterItem characterItem)
        {
            if (id != characterItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(characterItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterItemExists(id))
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

        // POST: api/CharacterItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CharacterItem>> PostCharacterItem(CharacterItem characterItem)
        {
            _context.CharacterItems.Add(characterItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacterItem), new { id = characterItem.Id }, characterItem);
        }

        // DELETE: api/CharacterItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CharacterItem>> DeleteCharacterItem(long id)
        {
            var characterItem = await _context.CharacterItems.FindAsync(id);
            if (characterItem == null)
            {
                return NotFound();
            }

            _context.CharacterItems.Remove(characterItem);
            await _context.SaveChangesAsync();

            return characterItem;
        }

        private bool CharacterItemExists(long id)
        {
            return _context.CharacterItems.Any(e => e.Id == id);
        }
    }
}
