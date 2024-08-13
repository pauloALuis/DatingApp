using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace API.Controllers
{

    // [ApiController]
    [Route("api/[Controller]")] // route: api/User
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Get users all/ get user by id - ASYNC 
        // GET: api/<ValuesController> // api/values
        // https://localhost:5001/api/Users/  
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }

        // GET api/<ValuesController>/5
        //https://localhost:5001/api/User/6   
        [HttpGet("{id}", Name = "User")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            return user;
        }

        #endregion ----------------------------------------------------------------------------------

    }
}