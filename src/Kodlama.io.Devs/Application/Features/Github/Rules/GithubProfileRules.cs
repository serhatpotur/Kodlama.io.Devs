using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Github.Rules
{
    public class GithubProfileRules
    {
        private readonly IGithubProfileRepository _repository;

        public GithubProfileRules(IGithubProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task GithubCanNotBeDuplicatedWhenInserted(string githubUrl)
        {
            IPaginate<GithubProfile> result = await _repository.GetListAsync(p => p.GithubUrl == githubUrl);
            if (result.Items.Any()) throw new BusinessException("Your Github name exists");
        }
    }
}
