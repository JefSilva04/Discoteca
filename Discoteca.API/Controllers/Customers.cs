using Discoteca.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Discoteca.Shared.Entities;


namespace Discoteca.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        // Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Attentions.ToListAsync());
        }

        // Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var customer = await _context.Attentions.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // Inserta un registro
        [HttpPost]
        public async Task<ActionResult> Post(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        // Actualizar o cambiar un registro
        [HttpPut]
        public async Task<ActionResult> Put(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        // Borra un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var AffectedRow = await _context.Attentions.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (AffectedRow == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}