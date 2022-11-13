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
        public async Task<GithubProfile> GithubProfileShouldExistBeforeDeleted(int id)
        {
            GithubProfile? profile = await _repository.GetAsync(x => x.Id == id); 

            if (profile == null)
            {
                throw new BusinessException("No profile exists");
            }

            return profile;
        }
        public async Task<GithubProfile> UserMustVerifiedBeforeProfileUpdated(int id)
        {
            GithubProfile? profile = await _repository.GetAsync(x => x.Id == id);

            if (profile == null)
            {
                throw new BusinessException("No profile exists");
            }

            return profile;
        }
        public void GithubProfileShouldExistWhenRequested(GithubProfile githubProfile)
        {
            if (githubProfile == null) throw new BusinessException("Requested github profile  does not exist");

        }
    }
}
