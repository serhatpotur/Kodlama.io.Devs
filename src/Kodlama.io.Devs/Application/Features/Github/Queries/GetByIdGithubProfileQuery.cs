using Application.Features.Github.Dtos;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Github.Queries
{
    public class GetByIdGithubProfileQuery : IRequest<GithubProfileGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdGithubProfileQueryHandler : IRequestHandler<GetByIdGithubProfileQuery, GithubProfileGetByIdDto>
        {
            private readonly IGithubProfileRepository _repository;
            private readonly IMapper _mapper;

            public GetByIdGithubProfileQueryHandler(IGithubProfileRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GithubProfileGetByIdDto> Handle(GetByIdGithubProfileQuery request, CancellationToken cancellationToken)
            {
                GithubProfile? githubProfile = await _repository.GetAsync(x => x.Id == request.Id);
                GithubProfileGetByIdDto mappedGithubProfile = _mapper.Map<GithubProfileGetByIdDto>(githubProfile);
                return mappedGithubProfile;
            }
        }
    }
}
