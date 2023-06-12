using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[api/Controller]")] // api/Movies
    public class MoviesController : ControllerBase
    {
        private readonly DataContext _context;

        public MoviesController(DataContext dataContext)
        {
            this._context = dataContext;
        }

        //
        [HttpGet]
        public ActionResult<IEnumerable<AppMovie>> GetMovies()
        {
            var moveis = _context.Movies.ToList();
            return moveis;
        }
        // GET api/<ValuesController>/5   
        [HttpGet("{id}")] //https://localhost:44319/api/Users/  6   
        public ActionResult<AppUser> GetMovie(int id)
        {
            var moveis = _context.Users.Find(id);

            return moveis == null ? BadRequest() : moveis;
        }
    }
}