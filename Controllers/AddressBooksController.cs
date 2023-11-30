using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBooksController : ControllerBase
    {
        private readonly AddressBookContext _context;

        public AddressBooksController(AddressBookContext context)
        {
            _context = context;
        }

        // GET: api/AddressBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressBook>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/AddressBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressBook>> GetAddressBook(int id)
        {
            var addressBook = await _context.TodoItems.FindAsync(id);

            if (addressBook == null)
            {
                return NotFound();
            }

            return addressBook;
        }

        // PUT: api/AddressBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressBook(int id, AddressBook addressBook)
        {
            if (id != addressBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressBookExists(id))
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

        // POST: api/AddressBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressBook>> PostAddressBook(AddressBook addressBook)
        {
            _context.TodoItems.Add(addressBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressBook", new { id = addressBook.Id }, addressBook);
        }

        // DELETE: api/AddressBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressBook(int id)
        {
            var addressBook = await _context.TodoItems.FindAsync(id);
            if (addressBook == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(addressBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressBookExists(int id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
