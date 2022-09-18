using Application.Features.Developers.Commands;
using Application.Features.Developers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDeveloperCommand registerDeveloperCommand)
        {
            RegisteredUserDto result = await Mediator.Send(registerDeveloperCommand);

            return Created("", result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDeveloperCommand loginDeveloperCommand)
        {
            RegisteredUserDto result = await Mediator.Send(loginDeveloperCommand);

            return Ok(result);
        }
    }
}
