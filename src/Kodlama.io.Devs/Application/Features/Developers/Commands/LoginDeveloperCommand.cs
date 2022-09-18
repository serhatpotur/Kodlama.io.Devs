using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Commands
{
    public class LoginDeveloperCommand : UserForLoginDto, IRequest<RegisteredUserDto>
    {
        public class LoginDeveloperCommandHandler : IRequestHandler<LoginDeveloperCommand, RegisteredUserDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            //public LoginDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            //{
            //    _developerRepository = developerRepository;
            //    _mapper = mapper;
            //    _tokenHelper = tokenHelper;
            //    _developerBusinessRules = developerBusinessRules;
            //}

            public LoginDeveloperCommandHandler(IDeveloperRepository developerRepository, IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<RegisteredUserDto> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
            {
                //await _developerBusinessRules.AuthLoginEmailCheck(request.Email);
                //Developer? developer = await _developerRepository.GetAsync(x => x.Email.ToLower() == request.Email.ToLower(), include: m => m.Include(uc => uc.UserOperationClaims).ThenInclude(x => x.OperationClaim));

                //List<OperationClaim> operationClaims = new List<OperationClaim>() { };

                //foreach (var userOperationClaim in developer.UserOperationClaims)
                //{
                //    operationClaims.Add(userOperationClaim.OperationClaim);
                //}

                //_developerBusinessRules.UserShouldExist(developer);

                //_developerBusinessRules.UserCredentialsShouldMatch(request.Password, developer.PasswordHash, developer.PasswordSalt);

                //AccessToken token = _tokenHelper.CreateToken(developer, operationClaims);

                //RegisteredUserDto mappedToken = _mapper.Map<RegisteredUserDto>(token);

                //return mappedToken;

                var user = await _userRepository.GetAsync(
                    u => u.Email.ToLower() == request.Email.ToLower(),
                    include: m => m.Include(c => c.UserOperationClaims).ThenInclude(x => x.OperationClaim));

                List<OperationClaim> operationClaims = new List<OperationClaim>() { };

                foreach (var userOperationClaim in user.UserOperationClaims)
                {
                    operationClaims.Add(userOperationClaim.OperationClaim);
                }

                _developerBusinessRules.UserShouldExist(user);

                _developerBusinessRules.UserCredentialsShouldMatch(request.Password, user.PasswordHash, user.PasswordSalt);

                AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

                RegisteredUserDto tokenDto = _mapper.Map<RegisteredUserDto>(token);

                return tokenDto;

            }
        }
    }
}
