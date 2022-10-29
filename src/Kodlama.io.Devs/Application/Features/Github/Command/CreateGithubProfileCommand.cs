using Application.Features.Github.Dtos;
using Application.Features.Github.Rules;
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
    public class CreateGithubProfileCommand : IRequest<CreatedGithubProfileDto>
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGithubProfileCommand, CreatedGithubProfileDto>
        {
            private readonly IGithubProfileRepository _guthubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileRules _githubProfileRules;

            public CreateGithubProfileCommandHandler(IGithubProfileRepository guthubProfileRepository, IMapper mapper, GithubProfileRules githubProfileRules)
            {
                _guthubProfileRepository = guthubProfileRepository;
                _mapper = mapper;
                _githubProfileRules = githubProfileRules;
            }

            public async Task<CreatedGithubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                await _githubProfileRules.GithubCanNotBeDuplicatedWhenInserted(request.GithubUrl);
                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile addedGithubProfile = await _guthubProfileRepository.AddAsync(mappedGithubProfile);
                CreatedGithubProfileDto createdDto = _mapper.Map<CreatedGithubProfileDto>(addedGithubProfile);
                return createdDto;
                //ProgrammingLanguageTechnology mappedPLTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                //ProgrammingLanguageTechnology createdPLTechnology = await _repository.AddAsync(mappedPLTechnology);
                //CreatedPLTechnologyDto createdDto = _mapper.Map<CreatedPLTechnologyDto>(createdPLTechnology);
                //return createdDto;
            }
        }
    }
}
