using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonApi.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;
        public PersonController(PersonContext context)
        {
            _context = context;
            if (_context.PersonItems.Count() == 0)
            {
                _context.PersonItems.Add(new PersonItem { Name = "Person1" });
                _context.SaveChanges();
            }
        }
    
    
        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonItem>>> GetPersonItems()
        {
            return await _context.PersonItems.ToListAsync();
        }

        // GET api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonItem>> GetPersonItem(long id)
        {
            var personItem = await _context.PersonItems.FindAsync(id);
            if (personItem == null)
            {
                return NotFound();
            }
            return personItem;
        }

        // POST api/Person
        [HttpPost]
        public async Task<ActionResult<PersonItem>> GetPersonItem(PersonItem item)
        {
            _context.PersonItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersonItem), new { id = item.Id }, item);
        }

        // PUT api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonItem(long id, PersonItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonItem(long id)
        {
            var personItem = await _context.PersonItems.FindAsync(id);
            if (personItem == null)
            {
                return NotFound();
            }
            _context.PersonItems.Remove(personItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
