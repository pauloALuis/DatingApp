using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenServices : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenServices(IConfiguration configuration)
        {
            var tokenKey = configuration["TokenKey"]??
            throw new Exception ("Cannot acess tokenkey from appsetting");
            
            if (tokenKey.Length < 64) throw new Exception("Your tokenkey needs to be longer");
            
            
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));//;
            
        }
        public string CreateToken(AppUser User)
        {
            var claims = new List<Claim>{

                new Claim (JwtRegisteredClaimNames.NameId, User.UserName)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature );
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity (claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token  = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}