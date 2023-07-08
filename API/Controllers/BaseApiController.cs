using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] // route: api/Base

    public class BaseApiController : ControllerBase
    {
        private readonly DataContext _dataContext;
/*
        public BaseApiController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }*/
    }
}