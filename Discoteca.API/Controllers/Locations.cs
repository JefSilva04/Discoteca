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
    [Route("api/locations")]
    public class LocationsController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationsController(DataContext context)
        {
            _context = context;
        }

        // Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Locations.ToListAsync());
        }

        // Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);

            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // Inserta un registro
        [HttpPost]
        public async Task<ActionResult> Post(Location location)
        {
            _context.Add(location);
            await _context.SaveChangesAsync();
            return Ok(location);
        }

        // Actualizar o cambiar un registro
        [HttpPut]
        public async Task<ActionResult> Put(Location location)
        {
            _context.Update(location);
            await _context.SaveChangesAsync();
            return Ok(location);
        }

        // Borra un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var AffectedRow = await _context.Locations.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (AffectedRow == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}