using Auth.Application.DTOs;
using Auth.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRegister loginRegister;

        public AuthController(ILoginRegister loginRegister)
        {
            this.loginRegister = loginRegister;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            try
            {
                var token = await loginRegister.Login(userDTO);
                return Ok(token);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("Rehister")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            try
            {
                if(await loginRegister.Register(userDTO))
                    return Ok();
                throw new Exception("somethsing wrong");
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
