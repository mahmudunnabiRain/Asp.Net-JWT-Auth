using Asp.Net_JWT_Auth.DAL.Services;
using Asp.Net_JWT_Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.Net_JWT_Auth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // POST api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequestModel authRequest)
        {
            var token = authService.Authenticate(authRequest.Username, authRequest.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "message:", "api running." };
        }

        /*// GET: api/auth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/auth/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
