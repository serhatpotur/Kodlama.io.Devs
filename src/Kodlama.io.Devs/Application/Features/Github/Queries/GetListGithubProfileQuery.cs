using Application.Features.Github.Models;
using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Github.Queries
{
    public class GetListGithubProfileQuery : IRequest<GithubProfileModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGithubProfileQueryHandler : IRequestHandler<GetListGithubProfileQuery, GithubProfileModel>
        {
            private readonly IGithubProfileRepository _repository;
            private readonly IMapper _mapper;

            public GetListGithubProfileQueryHandler(IGithubProfileRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GithubProfileModel> Handle(GetListGithubProfileQuery request, CancellationToken cancellationToken)
            {

                IPaginate<GithubProfile> githubProfiles = await _repository.GetListAsync(include: p => p.Include(p => p.User),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                GithubProfileModel mappedGithubProfileListModel = _mapper.Map<GithubProfileModel>(githubProfiles);
                return mappedGithubProfileListModel;
            }
        }
    }
}
