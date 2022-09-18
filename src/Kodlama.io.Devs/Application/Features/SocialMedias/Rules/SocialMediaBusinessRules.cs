using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task SocialMediaNameCanNotBeDuplicatedWhenInserted(string socialMediaName)
        {
            IPaginate<SocialMedia> result = await _socialMediaRepository.GetListAsync(p => p.SocialMediaName == socialMediaName);
            if (result.Items.Any()) throw new BusinessException("Social Media Name exists");

        }
        public void SocialMediaShouldExistWhenRequested(SocialMedia socialMedia)
        {
            if (socialMedia == null) throw new BusinessException("Requested programming language does not exist");

        }

        public async Task SocialMediaToBeUpdatedWaNotFound(int id)
        {
            var result = await _socialMediaRepository.GetAsync(p => p.Id == id);
            if (result == null) throw new BusinessException("Programming language id exists");

        }
    }
}
