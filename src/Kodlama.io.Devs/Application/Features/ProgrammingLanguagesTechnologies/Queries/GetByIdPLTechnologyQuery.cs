using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguagesTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguagesTechnologies.Queries
{
    public class GetByIdPLTechnologyQuery : IRequest<PLTechnologyGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdPLTechnologyQueryHandler : IRequestHandler<GetByIdPLTechnologyQuery, PLTechnologyGetByIdDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _repository;
            private readonly IMapper _mapper;

            public GetByIdPLTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PLTechnologyGetByIdDto> Handle(GetByIdPLTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? technology = await _repository.GetAsync(p => p.Id == request.Id);
                PLTechnologyGetByIdDto mappedtechnology = _mapper.Map<PLTechnologyGetByIdDto>(technology);
                return mappedtechnology;
                              
            }
        }
    }
}
