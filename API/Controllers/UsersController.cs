using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace API.Controllers
{

    // [ApiController]
    //[Route("api/[Controller]")] // route: api/User
    public class UsersController : BaseApiController
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /*
            public UsersController(DataContext dataContext)
           {
               _dataContext = dataContext;
           } */

        #region Get users all/ get user by id - Sinc

        /*



                // GET: api/<ValuesController> // api/values  
                [HttpGet] //https://localhost:5001/api/Users/  
                public ActionResult<IEnumerable<AppUser>> GetUsers()
                {
                    var users = _dataContext.Users.ToList();
                    return users;
                } 

                // GET api/<ValuesController>/5   
                [HttpGet("{id}")] //https://localhost:5001/api/Users/  6   
                public ActionResult <AppUser> GetUser(int id)
                {
                    var user = _dataContext.Users.Find(id);

                    return user ;
                }


                // POST api/<ValuesController>  
                // [HttpPost]
                // public void Post([FromBody] string value)
                // {

                // }
        */
        #endregion

        #region Get users all/ get user by id - ASYNC 
        // GET: api/<ValuesController> // api/values  
        [HttpGet] //https://localhost:5001/api/Users/  
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }

        // GET api/<ValuesController>/5   
        [HttpGet("{id}", Name = "User")] //https://localhost:5001/api/User/6   
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            return user;
        }
        #endregion

    }
}