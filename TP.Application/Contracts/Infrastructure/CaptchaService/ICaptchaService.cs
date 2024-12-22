using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Models.Captcha;

namespace TP.Application.Contracts.Infrastructure.CaptchaService
{
    public interface ICaptchaService
    {
        CaptchaResponse GenerateCaptcha(int expireTime, int length);
        public CaptchaStatus ValidateCaptcha(CaptchaValidationRequest captcha);


    }
}
