using Discoteca.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Discoteca.Shared.Entities;


namespace Discoteca.API.Controllers
{
    [ApiController]
    [Route("api/attentions")]
    public class AttentionsController : ControllerBase
    {
        private readonly DataContext _context;

        public AttentionsController(DataContext context)
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
            var attention = await _context.Attentions.FirstOrDefaultAsync(x => x.Id == id);

            if (attention == null)
            {
                return NotFound();
            }
            return Ok(attention);
        }

        // Inserta un registro
        [HttpPost]
        public async Task<ActionResult> Post(Attention attention)
        {
            _context.Add(attention);
            await _context.SaveChangesAsync();
            return Ok(attention);
        }

        // Actualizar o cambiar un registro
        [HttpPut]
        public async Task<ActionResult> Put(Attention attention)
        {
            _context.Update(attention);
            await _context.SaveChangesAsync();
            return Ok(attention);
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