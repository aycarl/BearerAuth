using BearerAuth.Authentication;
using BearerAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearerAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        readonly IConfiguration Configuration;

        public TokenController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody] LoginInputModel loginInput)
        {
            if (loginInput.Username != "james" && loginInput.Password != "bond")
            {
                return Unauthorized();
            }

            var token = new JwtTokenBuilder(Configuration)
                .Build(loginInput);

            return Ok(token);
        }
    }
}
