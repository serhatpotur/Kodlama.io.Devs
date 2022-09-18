using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguagesTechnologies.Models
{
    public class PLTechnologyListModel
    {
        public IList<PLTechnologyListDto> Items { get; set; }

    }
}
