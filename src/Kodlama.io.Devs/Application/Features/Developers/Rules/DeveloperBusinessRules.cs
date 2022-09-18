using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Rules
{
    public class DeveloperBusinessRules
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperBusinessRules(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public void UserShouldExist(Developer developer)
        {
            if (developer == null) throw new BusinessException("Kullanıcı yok");
        }
        public void UserShouldExist(User user)
        {
            if (user == null) throw new BusinessException("Kullanıcı yok");
        }

        public void UserCredentialsShouldMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("Yanlış kimlik bilgileri");
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _developerRepository.GetAsync(u => u.Email.ToLower().Equals(email.ToLower()));
            if (result != null) throw new BusinessException("Bu e-posta adresi zaten kayıtlı");
        }
        public async Task AuthLoginEmailCheck(string email)
        {
            User result = await _developerRepository.GetAsync(u => u.Email == email);
            if (result == null) throw new BusinessException("Such an email was not found in the system.");
        }
        }
}
