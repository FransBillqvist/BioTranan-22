using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Domain.Infrastructure.Data;


namespace API.Controllers;

[ApiController]
[Route("[controller]")]

public class ShowController : Controller
{
    BioContext _context;

    public ShowController(BioContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Show>>> GetAllShows()
    {

        var result = await _context.Shows.Include(z => z.Movie).Include(z => z.Saloon).ToListAsync();
        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpGet("{showid}")]
    [ActionName("GetShowById")]
    public async Task<ActionResult<Show>> GetShowById(int showid)
    {
        var result = await _context.Shows.Where(x => x.Id == showid).Include(x => x.Movie).Include(x => x.Saloon).FirstOrDefaultAsync();
        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }
    [HttpGet("movie/{movieid}")]

    public async Task<ActionResult<IEnumerable<Show>>> GetShowByMovieId(int movieid)
    {
        var result = await _context.Shows.Where(x => x.MovieId == movieid).ToListAsync();
        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }
    
    [HttpPut("{showid}")]
    public async Task<ActionResult<Show>> PutShowById(int showid, [FromBody] Show show)
    {
        var result = await _context.Shows.FindAsync(showid);
        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }
    
    [HttpDelete("{showid}")]
    public async Task<ActionResult<Show>> DeleteShowById(int showid)
    {
        var result = await _context.Shows.FindAsync(showid);
        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Show>> PostANewShow([FromBody] Show show)
    {
        var shows = await _context.Shows.Include(z => z.Movie).Include(z => z.Saloon).ToListAsync();
        if(shows.Any(x => x.FullDateAndTime <= show.FullDateAndTime && show.FullDateAndTime < x.FullDateAndTime.AddMinutes(x.Movie.Runtime)) )
        {
            return BadRequest("Show time is not available");
        }

        show.Movie = await _context.Movies.FindAsync(show.MovieId);
        show.Saloon = await _context.Saloons.FindAsync(show.SaloonId);
        if (show.Movie.IsANewBookingAllowed() == false)
        {
            return BadRequest("Du har använt alla dina bokningsrättigheter för denna film.");
        }
        else
        {
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostANewShow), new { id = show.Id }, show);
        }
        _context.Shows.Add(show);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostANewShow), new { id = show.Id }, show);
    }

}