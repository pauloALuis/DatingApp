using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[api/Controller]")] // route: api/User
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Get users all/ get user by id



        // GET: api/<ValuesController> // api/values  
        [HttpGet] //https://localhost:44319/api/Users/  
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = _dataContext.Users.ToList();

            return (users.Count ==  0) ? BadRequest() : users;
        } 

        // GET api/<ValuesController>/5   
        [HttpGet("{id}")] //https://localhost:44319/api/Users/  6   
        public ActionResult <AppUser> GetUser(int id)
        {
            var user = _dataContext.Users.Find(id);

            return user == null? BadRequest(): user ;
        }

        #endregion -----------------------------------------------------------

        #region Post user by id
        // POST api/<ValuesController>  
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {

        // }

        #endregion
    }
}