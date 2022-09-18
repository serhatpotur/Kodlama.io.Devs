using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Rules;
using Application.Features.SocialMedias.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands
{
    public class CreateSocialMediaCommand : IRequest<CreatedSocialMediaDto>
    {
        public int DeveloperId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public CreateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<CreatedSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _socialMediaBusinessRules.SocialMediaNameCanNotBeDuplicatedWhenInserted(request.SocialMediaName);

                SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                SocialMedia createdSocialMedia = await _socialMediaRepository.AddAsync(mappedSocialMedia);
                CreatedSocialMediaDto createdSocialMediaDto = _mapper.Map<CreatedSocialMediaDto>(createdSocialMedia);
                return createdSocialMediaDto;
            }
        }
    }
}
