using BearerAuth.Controllers;
using BearerAuth.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BearerAuth.Authentication
{
    public class JwtTokenBuilder
    {
        private readonly IConfiguration Configuration;

        public JwtTokenBuilder(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Build(LoginInputModel loginInput)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginInput.Username),
                new Claim("DisplayId", loginInput.DisplayId)
            };

            var token = new JwtSecurityToken(
                    issuer: "Bearer.Auth.X",
                    audience: "Bearer.Auth.X",
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(2),
                    signingCredentials: new SigningCredentials(
                        new JwtSecurityKey(Configuration).Create(), 
                        SecurityAlgorithms.HmacSha256)
                );

            return tokenHandler.WriteToken(token);
        }
    }
}
