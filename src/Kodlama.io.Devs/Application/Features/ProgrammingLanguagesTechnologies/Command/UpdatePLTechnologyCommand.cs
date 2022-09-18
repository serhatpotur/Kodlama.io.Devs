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
    public class UpdatePLTechnologyCommand : IRequest<UpdatedPLTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class UpdatePLTechnologyCommandHandler : IRequestHandler<UpdatePLTechnologyCommand, UpdatedPLTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _repository;

            private readonly IMapper _mapper;

            public UpdatePLTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<UpdatedPLTechnologyDto> Handle(UpdatePLTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? technology = await _repository.GetAsync(p => p.Id == request.Id);
                technology.Name = request.Name;
                technology.ProgrammingLanguageId = request.ProgrammingLanguageId;
                ProgrammingLanguageTechnology updatedTechnology = await _repository.UpdateAsync(technology);
                UpdatedPLTechnologyDto mappedTechnology = _mapper.Map<UpdatedPLTechnologyDto>(updatedTechnology);
                return mappedTechnology;
            }
        }
    }
}
