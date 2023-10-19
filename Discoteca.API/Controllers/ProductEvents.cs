using Discoteca.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Discoteca.Shared.Entities;


namespace Discoteca.API.Controllers
{
    [ApiController]
    [Route("api/productEvents")]
    public class ProductEventsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductEventsController(DataContext context)
        {
            _context = context;
        }

        // Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ProductEvents.ToListAsync());
        }

        // Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var productEvent = await _context.ProductEvents.FirstOrDefaultAsync(x => x.Id == id);

            if (productEvent == null)
            {
                return NotFound();
            }
            return Ok(productEvent);
        }

        // Inserta un registro
        [HttpPost]
        public async Task<ActionResult> Post(ProductEvent productEvent)
        {
            _context.Add(productEvent);
            await _context.SaveChangesAsync();
            return Ok(productEvent);
        }

        // Actualizar o cambiar un registro
        [HttpPut]
        public async Task<ActionResult> Put(ProductEvent productEvent)
        {
            _context.Update(productEvent);
            await _context.SaveChangesAsync();
            return Ok(productEvent);
        }

        // Borra un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var AffectedRow = await _context.ProductEvents.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (AffectedRow == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}