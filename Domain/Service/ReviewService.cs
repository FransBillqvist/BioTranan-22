using Domain.Infrastructure.Data;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace Domian.Service;
public class ReviewService
{

    private readonly BioContext _context;

    public ReviewService(BioContext context)
    {
        _context = context;
    }

    public async Task<bool> IsCodeValid(string revcode, int movieId)
    {
        var movieDetails = await _context.Movies.FindAsync(movieId);
        if(movieDetails == null)
        {
            return false;
        }
        return true;

        // var result = _context.Reviews.Where(x => x.Code == code);
        // if (result.Count() > 0)
        // {
        //     return false;
        // }
        // return true;
    }
}