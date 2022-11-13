using Application.Features.Github.Dtos;
using Application.Features.Github.Rules;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Github.Command
{
    public class DeleteGithubProfileCommand:IRequest<DeletedGithubProfileDto>
    {
        
            public int Id { get; set; }
            public class DeleteGithubProfileCommandHandler : IRequestHandler<DeleteGithubProfileCommand, DeletedGithubProfileDto>
            {
                private readonly IGithubProfileRepository _guthubProfileRepository;
                private readonly IMapper _mapper;
                private readonly GithubProfileRules _githubProfileRules;

                public DeleteGithubProfileCommandHandler(IGithubProfileRepository guthubProfileRepository, IMapper mapper, GithubProfileRules githubProfileRules)
                {
                    _guthubProfileRepository = guthubProfileRepository;
                    _mapper = mapper;
                    _githubProfileRules = githubProfileRules;
                }

                public async Task<DeletedGithubProfileDto> Handle(DeleteGithubProfileCommand request, CancellationToken cancellationToken)
                {
                    await _githubProfileRules.GithubProfileShouldExistBeforeDeleted(request.Id);
                    GithubProfile? profile = await _guthubProfileRepository.GetAsync(p => p.Id == request.Id);
                    GithubProfile deleteProfile = await _guthubProfileRepository.DeleteAsync(profile);
                    DeletedGithubProfileDto mappedGithubProfileDto = _mapper.Map<DeletedGithubProfileDto>(deleteProfile);
                    return mappedGithubProfileDto;
                }
            }
        
    }
}
