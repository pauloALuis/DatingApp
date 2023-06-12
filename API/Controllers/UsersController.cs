using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController ]
    [Route  ("[api/Controller]")] // route: api/User
    public class UsersController
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext) 
        {
            this._dataContext = dataContext;
        }
    }
}