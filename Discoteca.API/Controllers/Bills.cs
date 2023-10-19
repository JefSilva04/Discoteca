using Discoteca.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Discoteca.Shared.Entities;


namespace Discoteca.API.Controllers
{
    [ApiController]
    [Route("api/bills")]
    public class BillsController : ControllerBase
    {
        private readonly DataContext _context;

        public BillsController(DataContext context)
        {
            _context = context;
        }

        // Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Bills.ToListAsync());
        }

        // Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var bills = await _context.Bills.FirstOrDefaultAsync(x => x.Id == id);

            if (bills == null)
            {
                return NotFound();
            }
            return Ok(bills);
        }

        // Inserta un registro
        [HttpPost]
        public async Task<ActionResult> Post(Bill bill)
        {
            _context.Add(bill);
            await _context.SaveChangesAsync();
            return Ok(bill);
        }

        // Actualizar o cambiar un registro
        [HttpPut]
        public async Task<ActionResult> Put(Bill bill)
        {
            _context.Update(bill);
            await _context.SaveChangesAsync();
            return Ok(bill);
        }

        // Borra un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var AffectedRow = await _context.Bills.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (AffectedRow == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}