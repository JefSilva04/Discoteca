using Discoteca.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Discoteca.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Discoteca.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        // Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        // Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Inserta un registro
        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        // Actualizar o cambiar un registro
        [HttpPut]
        public async Task<ActionResult> Put(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        // Borra un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var AffectedRow = await _context.Products.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (AffectedRow == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}