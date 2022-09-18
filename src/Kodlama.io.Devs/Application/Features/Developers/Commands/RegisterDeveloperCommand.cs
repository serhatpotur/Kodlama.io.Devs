using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Commands
{
    public class RegisterDeveloperCommand : UserForRegisterDto, IRequest<RegisteredUserDto>
    {
        public class RegisterDeveloperCommandHandler : IRequestHandler<RegisterDeveloperCommand, RegisteredUserDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public RegisterDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<RegisteredUserDto> Handle(RegisterDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _developerBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                Developer mappedDeveloper = _mapper.Map<Developer>(request);
                mappedDeveloper.PasswordHash = passwordHash;
                mappedDeveloper.PasswordSalt = passwordSalt;

                Developer createdDeveloper = await _developerRepository.AddAsync(mappedDeveloper);
                AccessToken token = _tokenHelper.CreateToken(mappedDeveloper, new List<OperationClaim>());

                return new()
                {
                    Token = token.Token,
                    Expiration = token.Expiration
                };

                //await _developerBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);

                //HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                //Developer user = _mapper.Map<Developer>(request);
                //user.PasswordHash = passwordHash;
                //user.PasswordSalt = passwordSalt;
                //user.Status = true;

                //Developer registedUser = await _developerRepository.AddAsync(user);
                //AccessToken token = _tokenHelper.CreateToken(registedUser, new List<OperationClaim>());
                //RegisteredUserDto createdToken = _mapper.Map<RegisteredUserDto>(token);

                //return createdToken;
            }
        }

    }
}
