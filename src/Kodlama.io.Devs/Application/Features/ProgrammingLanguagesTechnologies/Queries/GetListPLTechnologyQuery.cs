using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguagesTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguagesTechnologies.Queries
{
    public class GetListPLTechnologyQuery : IRequest<PLTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListPLTechnologyQueryHandler : IRequestHandler<GetListPLTechnologyQuery, PLTechnologyListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _repository;
            private readonly IMapper _mapper;

            public GetListPLTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PLTechnologyListModel> Handle(GetListPLTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> technologies = await _repository.GetListAsync(include: p => p.Include(p => p.ProgrammingLanguage),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                PLTechnologyListModel mappedModel = _mapper.Map<PLTechnologyListModel>(technologies);
                return mappedModel;
            }
        }
    }
}
