using Application.Features.Github.Dtos;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Github.Models
{
    public class GithubProfileModel
    {
        public IList<GithubProfileListDto> Items { get; set; }

    }
}
