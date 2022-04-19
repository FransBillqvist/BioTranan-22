namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Domain.Entity;
    using Domain.Infrastructure.Data;
    using API.DTOs;
    // using API.Models;
    // using API.Services;

    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        BioContext _context;
        public MovieController(BioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            var result = await _context.Movies.ToListAsync();
            if(result == null)
            {
                return NoContent();
            }

            return Ok(result); 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {

            //later add id string and decrypt it to int.
            var result = await _context.Movies.FindAsync(id);
            if(result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> UpdateMovie(int id,[FromBody] UpdateMovie movie)
        {
            //later add id string and decrypt it to int.
            var result = await _context.Movies.FindAsync(id);
            if(result == null)
            {
                return NoContent();
            }
            result.Title = movie.Title;
            result.Native = movie.Native;
            result.Texted = movie.Texted;
            result.Runtime = movie.Runtime;
            result.Director = movie.Director;
            result.Genre = movie.Genre;
            result.Year = movie.Year;
            result.Country = movie.Country;
            result.Plot = movie.Plot;
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovieById(int id)
        {
            //later add id string and decrypt it to int.
            var result = await _context.Movies.FindAsync(id);
            if(result == null)
            {
                return NoContent();
            }
            _context.Movies.Remove(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult<Movie>> DeleteAllMovies()
        {
            var result = await _context.Movies.ToListAsync();
            if(result == null)
            {
                return NoContent();
            }
            _context.Movies.RemoveRange(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        
    }
}