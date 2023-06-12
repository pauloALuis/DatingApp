using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] // api/Movies
    public class MoviesController : ControllerBase
    {
        private readonly DataContext _context;

        public MoviesController(DataContext dataContext)
        {
            _context = dataContext;
        }

        // GET api/<ValuesController>/all 
        [HttpGet] //https://localhost:5001/api/Movies   
        public async Task<ActionResult<IEnumerable<AppMovie>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;
        }
        // GET api/<ValuesController>/5   
        [HttpGet("{id}")] //https://localhost:44319/api/Movie/6   
        public async Task<ActionResult<AppMovie>> GetMovie(int id)
        {
            var moveis = await _context.Movies.FindAsync(id);
            return moveis;
        }
    }
}