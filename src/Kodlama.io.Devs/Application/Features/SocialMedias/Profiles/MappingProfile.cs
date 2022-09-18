using Application.Features.ProgrammingLanguagesTechnologies.Command;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Application.Features.SocialMedias.Commands;
using Application.Features.SocialMedias.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SocialMedia, CreatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
        }
    }
}
