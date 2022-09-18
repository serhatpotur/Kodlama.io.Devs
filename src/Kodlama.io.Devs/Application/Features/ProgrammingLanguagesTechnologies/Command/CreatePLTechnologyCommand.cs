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

namespace Application.Features.ProgrammingLanguagesTechnologies.Command
{
    public class CreatePLTechnologyCommand : IRequest<CreatedPLTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId{ get; set; }
        public class CreatePLTechnologyCommandHandler : IRequestHandler<CreatePLTechnologyCommand, CreatedPLTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _repository;

            public CreatePLTechnologyCommandHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<CreatedPLTechnologyDto> Handle(CreatePLTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology mappedPLTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                ProgrammingLanguageTechnology createdPLTechnology = await _repository.AddAsync(mappedPLTechnology);
                CreatedPLTechnologyDto createdDto = _mapper.Map<CreatedPLTechnologyDto>(createdPLTechnology);
                return createdDto;
            }
        }
    }
}
