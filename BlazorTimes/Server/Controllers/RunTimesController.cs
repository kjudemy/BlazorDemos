using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorTimes.Server.Data;
using BlazorTimes.Shared.Models.Service;

namespace BlazorTimes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunTimesController : ControllerBase
    {
        private readonly TimesDbContext _context;
        static List<string> _names = new List<string> { "Poppy", "Lily", "Rose" };

        public RunTimesController(TimesDbContext context)
        {
            _context = context;
        }

        // GET: api/RunTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RunTime>>> GetTimes()
        {
            return await _context.Times.ToListAsync();
        }
        // GET: api/RunTimes/Names
        [HttpGet("names")]
        public ActionResult<IEnumerable<string>> GetNames()
        {
            return _names;
        }

        // GET: api/RunTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RunTime>> GetRunTime(int id)
        {
            var runTime = await _context.Times.FindAsync(id);

            if (runTime == null)
            {
                return NotFound();
            }

            return runTime;
        }

        // PUT: api/RunTimes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunTime(int id, RunTime runTime)
        {
            if (id != runTime.Id)
            {
                return BadRequest();
            }

            _context.Entry(runTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RunTimeExists(id))
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

        // POST: api/RunTimes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RunTime>> PostRunTime(RunTime runTime)
        {
            if( !_names.Contains(runTime.Name))
            {
                return BadRequest();
            }
            _context.Times.Add(runTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRunTime", new { id = runTime.Id }, runTime);
        }

        // DELETE: api/RunTimes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RunTime>> DeleteRunTime(int id)
        {
            var runTime = await _context.Times.FindAsync(id);
            if (runTime == null)
            {
                return NotFound();
            }

            _context.Times.Remove(runTime);
            await _context.SaveChangesAsync();

            return runTime;
        }

        private bool RunTimeExists(int id)
        {
            return _context.Times.Any(e => e.Id == id);
        }
    }
}
