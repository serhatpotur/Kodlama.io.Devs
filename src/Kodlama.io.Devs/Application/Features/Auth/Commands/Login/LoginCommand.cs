using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginedDto>
    {
        //public UserForLoginDto UserForLoginDto { get; set; }
        //public string IpAddress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAdress { get; set; }
        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly ITokenHelper _tokenHelper;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                //var user = await _userRepository.GetAsync(x => x.Email == request.Email);

                // _authBusinessRules.AuthLoginEmailCheck(user.Email);
                // _authBusinessRules.CheckIfPasswordIsCorrect(request.Password, user.PasswordHash, user.PasswordSalt);

                //var userClaims = await _userOperationClaimRepository.GetListAsync(x =>
                //       x.UserId == user.Id,
                //   include: x => x.Include(c => c.OperationClaim),
                //   cancellationToken: cancellationToken);

                //var accessToken = _tokenHelper.CreateToken(user, userClaims.Items.Select(x => x.OperationClaim).ToList());

                //return accessToken;

                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                _authBusinessRules.AuthLoginEmailCheck(user?.Email);
                _authBusinessRules.CheckIfPasswordIsCorrect(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);

                AccessToken accessToken = await _authService.CreateAccessToken(user);
                RefreshToken refreshToken = await _authService.CreateRefreshToken(user, request.IpAdress);
                await _authService.AddRefreshToken(refreshToken);

                LoginedDto loggedDto = new()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                };
                return loggedDto;

            }
        }
    }
}
