using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries;
using Application.Features.ProgrammingLanguagesTechnologies.Command;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Application.Features.ProgrammingLanguagesTechnologies.Models;
using Application.Features.ProgrammingLanguagesTechnologies.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologyController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListPLTechnologyQuery query = new GetListPLTechnologyQuery() { PageRequest = pageRequest };
            PLTechnologyListModel listModel = await Mediator.Send(query);
            return Ok(listModel);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPLTechnologyQuery getByIdQuery)
        {
            PLTechnologyGetByIdDto getById = await Mediator.Send(getByIdQuery);
            return Ok(getById);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePLTechnologyCommand command)
        {
            CreatedPLTechnologyDto technologyDto = await Mediator.Send(command);
            return Created("", technologyDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePLTechnologyCommand deleteCommand)
        {
            DeletedPLTechnologyDto technologyDto = await Mediator.Send(deleteCommand);
            return Ok(technologyDto);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePLTechnologyCommand updateCommand)
        {
            UpdatedPLTechnologyDto technologyDto = await Mediator.Send(updateCommand);
            return Ok(technologyDto);
        }
    }
}
