
using Microsoft.AspNetCore.Mvc;
using TP.Application;
using TP.Application.Contracts.Infrastructure.AccountSerivce;

namespace TestProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }
        [ServiceFilter(typeof(ValidateCaptchaAttribute))]
        [HttpPost("login")]

        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var response=await authService.Login(request);
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterationResponse>> Register(RegisterationRequest request) { 
            var response=await authService.Register(request);
            return Ok(response);
        }
    }
}
