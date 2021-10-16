using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net_JWT_Auth.DAL.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        private readonly IDictionary<string, string> creds = new Dictionary<string, string>
        {
            {"rain", "1234"},
            {"unknown", "0000"},
        };
        private readonly string tokenKey;


        public string Authenticate(string username, string password)
        {
            if( !creds.Any(c => c.Key == username && c.Value == password) )
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
