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
    public class DeletePLTechnologyCommand : IRequest<DeletedPLTechnologyDto>
    {
        public int Id { get; set; }
        public class DeletePLTechnologyCommandHandler : IRequestHandler<DeletePLTechnologyCommand, DeletedPLTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _repository;

            public DeletePLTechnologyCommandHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<DeletedPLTechnologyDto> Handle(DeletePLTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? technology = await _repository.GetAsync(p => p.Id == request.Id);
                ProgrammingLanguageTechnology deletedeTechnology = await _repository.DeleteAsync(technology);
                DeletedPLTechnologyDto mappedTechnologyDto = _mapper.Map<DeletedPLTechnologyDto>(deletedeTechnology);
                return mappedTechnologyDto;
            }
        }
    }
}
