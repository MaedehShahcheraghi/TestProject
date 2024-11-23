using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.Contracts.Infrastructure.AccountSerivce
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegisterationResponse> Register(RegisterationRequest request);

    }
}
