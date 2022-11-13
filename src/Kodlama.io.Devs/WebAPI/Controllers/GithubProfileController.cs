using Application.Features.Github.Command;
using Application.Features.Github.Dtos;
using Application.Features.Github.Models;
using Application.Features.Github.Queries;
using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries;
using Application.Features.ProgrammingLanguagesTechnologies.Command;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.Github.Command.DeleteGithubProfileCommand;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubProfileController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGithubProfileQuery getList = new() { PageRequest = pageRequest };
            GithubProfileModel listModel = await Mediator.Send(getList);
            return Ok(listModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGithubProfileQuery getByIdQuery)
        {
            GithubProfileGetByIdDto getById = await Mediator.Send(getByIdQuery);
            return Ok(getById);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGithubProfileCommand createGithubProfileCommand)
        {
            CreatedGithubProfileDto result = await Mediator.Send(createGithubProfileCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGithubProfileCommand deleteGithubProfileCommand)
        {
            var result = await Mediator.Send(deleteGithubProfileCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubProfileCommand updateGithubProfileCommand)
        {
            var result = await Mediator.Send(updateGithubProfileCommand);
            return Ok(result);
        }


    }
}
