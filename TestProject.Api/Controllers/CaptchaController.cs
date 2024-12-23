using Microsoft.AspNetCore.Mvc;
using TP.Application.Contracts.Infrastructure.CaptchaService;

namespace TestProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : Controller
    {
        private readonly ICaptchaService _captchaService;

        public CaptchaController(ICaptchaService captchaService)
        {
            _captchaService = captchaService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateCaptchaCode(int expireTime)
        {
            var result=await _captchaService.GenerateCaptcha(expireTime,6);
            switch (result.CaptchaStatus)
            { 
                case TP.Application.Models.Captcha.CaptchaStatus.Ok:
                    return Ok(result);
                case TP.Application.Models.Captcha.CaptchaStatus.NotFound:
                    return NotFound(result);
                case TP.Application.Models.Captcha.CaptchaStatus.BadRequest:
                   return BadRequest( result);
                default:
                    break;
            }
            return StatusCode(500,new { Message = "Internal server Error" });
        }
    }
}
