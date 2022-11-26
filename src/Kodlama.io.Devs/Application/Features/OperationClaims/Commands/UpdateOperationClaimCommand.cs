using Application.Features.Github.Rules;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            IOperationClaimRepository _operationClaimRepository;
            IMapper _mapper;
            OperationClaimsRules _operationClaimsRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimsRules operationClaimsRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimsRules = operationClaimsRules;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimsRules.OperationClaimNameCanNotBeDuplicatedWhenCreated(request.Name);

                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
                _operationClaimsRules.OperationClaimShouldExistWhenRequested(operationClaim);
                operationClaim.Name = request.Name;
                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaim);
                UpdatedOperationClaimDto mappedDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
                return mappedDto;
            }
        }
    }
}
