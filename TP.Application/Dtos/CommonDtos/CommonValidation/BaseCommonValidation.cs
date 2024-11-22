using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;

namespace TP.Application.Dtos.CommonDtos.CommonValidation
{
    public class BaseCommonValidation:AbstractValidator<BaseDto>
    {
        private readonly IUserRepository _userRepository;

        public BaseCommonValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
         

            RuleFor(p => p.CreatedBy)
                .MustAsync(async (CreatedBy, token) =>
                {
                    var leaveTypeExist = await _userRepository.ExistByIdAsync(CreatedBy);
                    return leaveTypeExist == true;
                })
                .WithMessage("{PropertyName} does not exist.");

        }
    }
}
