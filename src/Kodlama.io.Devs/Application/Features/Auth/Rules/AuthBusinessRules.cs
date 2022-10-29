using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists");

        }
        public async Task AuthLoginEmailCheck(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null) throw new BusinessException("Such an email was not found in the system.");
        }
        public void CheckIfPasswordIsCorrect(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool control = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!control) throw new BusinessException("Password is not correct");
        }
    }
}
