using Application.Features.Developers.Commands;
using Application.Features.Developers.Dtos;
using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using AutoMapper;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
           // CreateMap<Developer, RegisteredUserDto>().ReverseMap();
            CreateMap<Developer, RegisterDeveloperCommand>().ReverseMap();
            CreateMap<RegisteredUserDto, AccessToken>().ReverseMap();

            //CreateMap<Developer, LoginedUserDto>().ReverseMap();
            //CreateMap<Developer, LoginDeveloperCommand>().ReverseMap();
           // CreateMap<LoginedUserDto, AccessToken>().ReverseMap();
        }
    }
}
