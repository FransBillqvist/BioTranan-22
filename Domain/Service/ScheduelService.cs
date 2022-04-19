using Domain.Infrastructure.Data;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service;
public class ScheduelService
{
    readonly BioContext _context;

    public ScheduelService(BioContext context)
    {
        _context = context;
    }

    public IEnumerable<Show> GetAllNotAiredMoviesOnScheduel()
    {
        var result = _context.Shows.Where(x => x.IsUsed == false);
        return result.ToList();
    }
    

    public async Task<IEnumerable<Movie>> GetAllAvailableMovies()
    {
        var result = await _context.Movies.Where(x => x.BookedUses < x.NumberOfUses).ToListAsync();
        return result;
    }

    // public async Task<bool> IsDateAndTimeAvailable(int movieId,int saloonId, DateOnly date, TimeOnly time)
    // {
    //     var todaydate = DateOnly.FromDateTime(DateTime.Now);
    //     DateTime recastdate = date.ToDateTime();
    //     recastdate += time.ToTimeSpan();
    //     var getMovieDetails = await _context.Movies.FindAsync(movieId);
    //     var getSaloonDetails = await _context.Saloons.FindAsync(saloonId);
    //     if(getMovieDetails == null || getSaloonDetails == null)
    //     {
    //         return false;
    //     }
    //     if(date.ToDateTime + (int)time+ getMovieDetails.Runtime + getSaloonDetails.MaintenanceBuffer < getSaloonDetails.ClosedAfter)
    //     {
    //         ///kolla om det finns något scheduel på den datum och tid

    //     }
    //     // var result = await _context.Movies.ToListAsync();
    //     return true;
    // }

    // Fråga efter dag och tid

    //hämta alla vinsingar med dagen

    // Foreach visningar hämta starttid + filmlängd + maintenancetime
    //Om starttid + filmlängd + maintenancetime < closedafter så returna true
    //Om starttid + filmlängd + maintenancetime > closedafter så returna false
    //Om starttid + filmlängd + maintenancetime < än andra filmer så returna ?!?!??!
    public bool IsMovieAvailableOnScheduel(int movieId, int date, int time) //version 1
    {
        // var result = _context.Shows.Where(x => x.MovieId == movieId && x.showDate && x.showTime == time);
        // if (result.Count() > 0)
        // {
        //     return false;
        // }
        return true;
    }
}