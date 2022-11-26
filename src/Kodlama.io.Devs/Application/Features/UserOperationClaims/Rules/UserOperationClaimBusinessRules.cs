using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _repository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository repository)
        {
            _repository = repository;
        }
        public async Task UserAndOperationClaimMustExistBeforeAdded(int userId, int operationClaimId)
        {
            var user = await _repository.GetAsync(e => e.UserId == userId && e.OperationClaimId==operationClaimId);

            if (user != null) throw new BusinessException("User and Claim does not exist");

        }
        public async Task UserOperationClaimIdShouldBeExist(int id)
        {
            var userOperationCalim = await _repository.GetListAsync(o => o.Id == id);
            if (userOperationCalim == null) throw new BusinessException("Operation Claim id not exists");
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("User operation claim does not exists !");
        }
    }
}
