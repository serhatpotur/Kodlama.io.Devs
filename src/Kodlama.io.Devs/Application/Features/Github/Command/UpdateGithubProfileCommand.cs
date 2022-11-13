using Application.Features.Github.Dtos;
using Application.Features.Github.Rules;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
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
    public class UpdateGithubProfileCommand : IRequest<UpdatedGithubProfileDto>
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public class UpdateGithubProfileCommandHandler : IRequestHandler<UpdateGithubProfileCommand, UpdatedGithubProfileDto>
        {
            private readonly IGithubProfileRepository _guthubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileRules _githubProfileRules;

            public UpdateGithubProfileCommandHandler(IGithubProfileRepository guthubProfileRepository, IMapper mapper, GithubProfileRules githubProfileRules)
            {
                _guthubProfileRepository = guthubProfileRepository;
                _mapper = mapper;
                _githubProfileRules = githubProfileRules;
            }

            public async Task<UpdatedGithubProfileDto> Handle(UpdateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                await _githubProfileRules.GithubCanNotBeDuplicatedWhenInserted(request.GithubUrl);

                GithubProfile? githubProfile = await _guthubProfileRepository.GetAsync(p => p.Id == request.Id);
                _githubProfileRules.GithubProfileShouldExistWhenRequested(githubProfile);

                githubProfile.GithubUrl = request.GithubUrl;

                GithubProfile updatedGithubProfile = await _guthubProfileRepository.UpdateAsync(githubProfile);

                UpdatedGithubProfileDto updatetedGithubProfileDto = _mapper.Map<UpdatedGithubProfileDto>(updatedGithubProfile);

                return updatetedGithubProfileDto;
            }
        }

    }
}
