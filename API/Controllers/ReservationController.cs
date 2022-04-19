using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Domain.Infrastructure.Data;
namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationController : ControllerBase
{

    BioContext _context;
    public ReservationController(BioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> PostReservation([FromBody] Reservation reservation)
    {
        reservation.show = await _context.Shows.Include(x => x.Movie).Include(x => x.Saloon).FirstOrDefaultAsync(x => x.Id == reservation.ShowId);
        reservation.show.BookSeats(reservation.SeatsBooked);
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostReservation), new { id = reservation.Id }, reservation);
    }
    [HttpGet]
    public async Task<ActionResult<List<Reservation>>> GetAllReservations()
    {
        var result = await _context.Reservations.ToListAsync();
        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }
    [HttpGet("Show/{showId:int}")]

    public async Task<ActionResult<List<Reservation>>> GetAllReservationByShowId(int showId)
    {

        var result = await _context.Reservations.Include(x => x.show).ThenInclude(x => x.Saloon).Include(x => x.show.Movie).Where(x => x.ShowId == showId).ToListAsync();

        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpGet("{Id:int}")]
    public async Task<ActionResult<Reservation>> GetReservationById(int Id)
    {
        var result = await _context.Reservations.Include(x => x.show).ThenInclude(x => x.Saloon).Include(x => x.show.Movie).FirstOrDefaultAsync(x => x.Id == Id);
        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpDelete("{Id:int}")]
    public async Task<ActionResult<Reservation>> DeleteReservation(int Id)
    {
        var result = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == Id);
        if (result == null)
        {
            return NoContent();
        }

        _context.Reservations.Remove(result);
        await _context.SaveChangesAsync();

        return Ok(result);
    }
}