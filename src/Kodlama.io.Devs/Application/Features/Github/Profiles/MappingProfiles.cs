using Application.Features.Github.Command;
using Application.Features.Github.Dtos;
using Application.Features.Github.Models;
using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguagesTechnologies.Command;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Application.Features.ProgrammingLanguagesTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Github.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubProfile, CreatedGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();

            CreateMap<GithubProfile, DeletedGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, DeleteGithubProfileCommand>().ReverseMap();

            CreateMap<GithubProfile, UpdatedGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, UpdateGithubProfileCommand>().ReverseMap();

            CreateMap<GithubProfile, GithubProfileListDto>().ReverseMap();
            CreateMap<IPaginate<GithubProfile>, GithubProfileModel>().ReverseMap();

            CreateMap<GithubProfile, GithubProfileGetByIdDto>().ReverseMap();



        }
    }
}
