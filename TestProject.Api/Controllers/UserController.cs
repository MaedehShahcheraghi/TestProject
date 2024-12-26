using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP.Application.Constants;
using TP.Application.Contracts.Infrastructure.AccountSerivce;

namespace TestProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService authService;

        public UserController(IAuthService authService)
        {
            this.authService = authService;
        }

        [Authorize(Policy = CustomPloicy.AccessToAddUserRole)]
        [HttpPost("AddUserRole/{userId}")]
        public async Task<IActionResult> AddUserRole(string userId,[FromBody]string roleName) { 
                var result=await authService.AssignRole(userId, roleName);
            if (result )
            {
                return Ok(result);

            }
            return BadRequest();
        }

    }
}
