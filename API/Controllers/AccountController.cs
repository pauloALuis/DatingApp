using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _dataContext;

        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Post: api/<ValuesController> // api/values  
        //https://localhost:5001/api/account/register?username=sam&password=password
        [HttpPost("register")] //https://localhost:5001/api/account/register  
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if (await UserIsNullOrEmpty(registerDto.UserName) ||
             await UserIsNullOrEmpty(registerDto.Password))
            {
                return BadRequest("UserName/Password is null or empty");
            }


            if (!await UserExists(registerDto.UserName))
            {
                using var hmac = new HMACSHA512();
                var user = new AppUser
                {
                    UserName = registerDto.UserName.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                    PasswordSalt = hmac.Key
                };
                //await _dataContext.Users.ToListAsync();
                _dataContext.Users.Add(user);
                await _dataContext.SaveChangesAsync();

                return user;
            }

            return BadRequest("This user already exists");
        }
        #region private methon zone
        private async Task<bool> UserExists(string username)
        {

            return await _dataContext.Users.AnyAsync(user => user.UserName == username.ToLower());
        }
        /*      private async Task<bool> UserExists(LoginDto userLogin)
            {
                using var hmac = new HMACSHA512();

                return await _dataContext.Users.SingleOfDefaultAsync(user => user.UserName == userLogin.UserName.ToLower() &&
                 user.PasswordHash == hmac.ComputeHash(Dencoding.UTF8.GetBytes(userLogin.Password)) &&
                 user.PasswordSalt ==  hmac.GetHashCode);
            } */


        private async Task<bool> UserIsNullOrEmpty(string username)
        {

            return String.IsNullOrEmpty(username);
        }
        // Post: api/<ValuesController> // api/values  
        //https://localhost:5001/api/account/Login?username=sam&password=password
        [HttpPost("login")] //https://localhost:5001/api/account/login
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(user => user.UserName == loginDto.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid password");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");

            }
            return user;
        }

        #endregion ---------------   
    }
}