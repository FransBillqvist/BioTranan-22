using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MovieContextSeed
{
    public static async Task SeedAsync(MovieContext context)
    {
        if(! await context.Movies.AnyAsync())
        {
            await context.Movies.AddRangeAsync(GetPresetMovies());
            await context.SaveChangesAsync();
        }  
    }
    private static IEnumerable<Movie> GetPresetMovies()
    {
        return new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Native = "Чернобыль",
                Texted = "Чернобыль",
                Runtime = 142,
                Director = "Frank Darabont",
                Genre = "Crime, Drama",
                Year = 1994,
                Rating = "R",
                RatingValue = 9.3,
                Country = "USA",
                Plot = "Two imprisoned",
                NumberOfUses = 5
            }
        };
    }
}