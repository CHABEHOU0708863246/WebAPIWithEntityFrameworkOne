using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIWithEntityFrameworkOne.Models;

namespace WebAPIWithEntityFrameworkOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _dbContext;

        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Method action CRUD
        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _dbContext.Movies.ToListAsync();
        }


        /// <summary>
        /// Gel Movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        /// <summary>
        /// Post Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(movie).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        private bool MovieExists(long id)
        {
            return (_dbContext.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return NoContent();
                
        }
       
        #endregion
    }
}
