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

namespace Application.Features.ProgrammingLanguagesTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageTechnology, CreatedPLTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, CreatePLTechnologyCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, DeletedPLTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, DeletePLTechnologyCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, UpdatedPLTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, UpdatePLTechnologyCommand>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, PLTechnologyListDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguageTechnology>, PLTechnologyListModel>().ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, PLTechnologyListDto>().ReverseMap();

        }
    }
}
