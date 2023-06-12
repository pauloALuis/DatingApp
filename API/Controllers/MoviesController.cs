using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route ("[api/Controller]")] // api/Movies
    public class MoviesController
    {    
        private readonly DataContext _context ;

        public MoviesController(DataContext dataContext) 
        {
            this._context = dataContext;
        }

    }
}