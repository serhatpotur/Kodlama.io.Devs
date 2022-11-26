using Application.Features.UserOperationClaims.Commands;
using Application.Features.UserOperationClaims.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand request)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(request);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand request)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
