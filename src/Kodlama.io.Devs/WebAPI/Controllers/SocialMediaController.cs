using Application.Features.ProgrammingLanguagesTechnologies.Command;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Application.Features.SocialMedias.Commands;
using Application.Features.SocialMedias.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand command)
        {
            CreatedSocialMediaDto result = await Mediator.Send(command);
            return Created("", result);
        }
    }
}
