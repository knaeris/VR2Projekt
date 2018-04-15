using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VR2Identity.Data;
using VR2Identity.Models;

namespace VR2Identity.Controllers.API
{
    [Produces("application/json")]
    [Route("api/FooBars")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class FooBarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FooBarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FooBars
        [HttpGet]
        public IEnumerable<FooBar> GetFooBars()
        {
            return _context.FooBars;
        }

        // GET: api/FooBars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooBar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fooBar = await _context.FooBars.SingleOrDefaultAsync(m => m.FooBarId == id);

            if (fooBar == null)
            {
                return NotFound();
            }

            return Ok(fooBar);
        }

        // PUT: api/FooBars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFooBar([FromRoute] int id, [FromBody] FooBar fooBar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fooBar.FooBarId)
            {
                return BadRequest();
            }

            _context.Entry(fooBar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FooBarExists(id))
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

        // POST: api/FooBars
        [HttpPost]
        public async Task<IActionResult> PostFooBar([FromBody] FooBar fooBar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FooBars.Add(fooBar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFooBar", new { id = fooBar.FooBarId }, fooBar);
        }

        // DELETE: api/FooBars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooBar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fooBar = await _context.FooBars.SingleOrDefaultAsync(m => m.FooBarId == id);
            if (fooBar == null)
            {
                return NotFound();
            }

            _context.FooBars.Remove(fooBar);
            await _context.SaveChangesAsync();

            return Ok(fooBar);
        }

        private bool FooBarExists(int id)
        {
            return _context.FooBars.Any(e => e.FooBarId == id);
        }
    }
}