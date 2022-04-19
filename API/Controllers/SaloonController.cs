using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Infrastructure.Data;
using API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


[ApiController]
[Route("[controller]")]
public class SaloonController : Controller
{
    BioContext _context;
    public SaloonController(BioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Saloon>> PostSaloon([FromBody] Saloon saloon)
    {
        _context.Saloons.Add(saloon);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSaloonById), new { id = saloon.Id }, saloon);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Saloon>>> GetAllSaloons()
    {
        var result = await _context.Saloons.ToListAsync();
        if(result == null)
        {
            return NoContent();
        }

        return Ok(result); 
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Saloon>> GetSaloonById(int id)
    {

        //later add id string and decrypt it to int.
        var result = await _context.Saloons.FindAsync(id);
        if(result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Saloon>> UpdateSaloonById(int id, [FromBody] UpdateSaloon saloon)
    {
        var result = await _context.Saloons.FindAsync(id);
            if(result == null)
            {
                return NoContent();
            }
        result.Name = saloon.Name;
        result.Seats = saloon.Seats;
        result.OpenFrom = saloon.OpenFrom;
        result.ClosedAfter = saloon.ClosedAfter;
        result.MaintenanceBuffer = saloon.MaintenanceBuffer;

        await _context.SaveChangesAsync();
        return Ok(saloon);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Saloon>> DeleteSaloonById(int id)
    {
        var result = await _context.Saloons.FindAsync(id);
        if(result == null)
        {
            return NoContent();
        }
        _context.Saloons.Remove(result);
        await _context.SaveChangesAsync();
        return Ok(result);
    }

}